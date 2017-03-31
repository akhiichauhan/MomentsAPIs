using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moments.APIs.DataContract;
using Moments.APIs.ServiceContract;
using Moments.Data.MySqlDataSource.ORM;

namespace Moments.Data.MySqlDataSource
{
    public class MySqlDataSource:IDataSource
    {

        public async Task<ExecutionResponse> CreateUser(User user)
        {
            ExecutionResponse response = new ExecutionResponse();
            try
            {
                using (momentsEntities context = new momentsEntities())
                {

                    //Save the information in person (master table)
                    int personId = CreatePerson(context, user);

                    //Save the data in user
                    user newUser = new user();
                    newUser.person = new person()
                    {
                        personId = personId
                    };
                    newUser.FirstName = user.Name?.FirstName;
                    newUser.LastName = user.Name?.LastName;
                    newUser.emailId = user.Email;
                    newUser.gender = user.Gender.ToString();
                    newUser.friends = GetFriends(user.FriendsList);

                    context.users.Add(newUser);
                    context.SaveChanges();
                    response.ExecutionData.Add(KeyStore.User.UserId, newUser.userid);
                    response.ExecutionData.Add(KeyStore.User.PersonId, personId);
                }

            }
            catch (Exception e)
            {
                response.Status = KeyStore.ExecutionStatus.Failure;
                response.Errors.Add(KeyStore.ErrorMessages.UserCreationFailure);
            }

            return response;
        }

        private ICollection<friend> GetFriends(List<string> friendsList)
        {
            var friends = new List<friend>();
            foreach (var friendId in friendsList)
            {
                friends.Add(new friend() {userId =int.Parse(friendId)});
            }
            return friends;
        }

        private int CreatePerson(momentsEntities context, User user)
        {
            person person = new person()
            {
               CreatedOn = DateTime.Now
            };
            context.persons.Add(person);
            context.SaveChanges();
            return person.personId;
        }

        public async Task<ExecutionResponse> SavePhoto(PhotosDetail photoDetails)
        {
            ExecutionResponse response = new ExecutionResponse();
            try
            {
                using (momentsEntities context = new momentsEntities())
                {

                    photo newPhoto = new photo
                    {
                        user =new user() {userid = int.Parse(photoDetails.UserId)},
                        location = photoDetails.Location,
                        url = photoDetails.PhotoUrl
                    };
                    context.photos.Add(newPhoto);
                    context.SaveChanges();
                    response.ExecutionData.Add(KeyStore.Photo.PhotoId, newPhoto.PhotoId);
                }

            }
            catch (Exception e)
            {
                response.Status = KeyStore.ExecutionStatus.Failure;
                response.Errors.Add(KeyStore.ErrorMessages.PhotoSaveFailure);
            }

            return response;
        }

        public async Task<ExecutionResponse> GetPhotos(User user)
        {
            ExecutionResponse response = new ExecutionResponse();
            try
            {
                List<string> photoUrls = new List<string>();
                using (momentsEntities context = new momentsEntities())
                {
                    int personIdAsInt = int.Parse(user.PersonId);
                    int userIdAsInt = int.Parse(user.UserId);

                    //Get the user photos from photo tags
                    List<int?> photoIds =
                        context.phototags.Include("photos")
                            .Where(person => person.personId == personIdAsInt)
                            .Select(photo => photo.photoId).ToList();

                    //Get the user photos from photos for the users or from the taged photos
                    photoUrls =
                        context.photos.Where(phts => photoIds.Contains(phts.PhotoId) || (phts.user.userid== userIdAsInt))
                            .Select(phts => phts.url)
                            .ToList();

                    response.ExecutionData.Add(KeyStore.Photo.PhotoUrls,photoUrls);

                }

            }
            catch (Exception e)
            {
                response.Status = KeyStore.ExecutionStatus.Failure;
                response.Errors.Add(KeyStore.ErrorMessages.PhotoRetrievalFailure);
            }

            return response;
        }

        public async Task<ExecutionResponse> SavePhotoMetadata(PhotoMetadata photoMetadata)
        {
            ExecutionResponse response = new ExecutionResponse();
            try
            {
                using (momentsEntities context = new momentsEntities())
                {
                    foreach (var friendId in photoMetadata.PersonIds)
                    {
                        phototag photoTag = new phototag
                        {
                            photoId = int.Parse(photoMetadata.PhotoId),
                            personId = int.Parse(friendId)
                        };
                        context.phototags.Add(photoTag);
                    }
                    
                    context.SaveChanges();
                }

            }
            catch (Exception e)
            {
                response.Status = KeyStore.ExecutionStatus.Failure;
                response.Errors.Add(KeyStore.ErrorMessages.PhotoTagSaveFailure);
            }

            return response;
        }
    }
}
