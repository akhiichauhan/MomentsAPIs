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
                    user newUser = new user {
                        person = {personId = personId},
                        FirstName = user.Name.FirstName,
                        LastName = user.Name.LastName,
                        emailId = user.Email,
                        gender = user.Gender.ToString(),

                        friends = GetFriends(user.FriendsList)
                    };
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
            person person = new person();
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
                        user = {userid = int.Parse(photoDetails.UserId)},
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
                    //Get the user photos from photo tags
                    List<string> photoIds =
                        context.phototags.Include("photos")
                            .Where(person => person.personId == int.Parse(user.PersonId))
                            .Select(photo => photo.photoId.ToString()).ToList();

                    //Get the user photos from photos for the users or from the taged photos
                    photoUrls =
                        context.photos.Where(phts => photoIds.Contains(phts.PhotoId.ToString()) || (phts.user.userid.ToString()==user.UserId))
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
