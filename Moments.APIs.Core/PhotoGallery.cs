using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Amazon.S3;
using Amazon.S3.Model;
using Moments.APIs.DataContract;
using Moments.APIs.ServiceContract;
using Moments.Data.MySqlDataSource;
using Amazon.Lambda;
using Amazon;

namespace Moments.APIs.Core
{
    public class PhotoGallery : IPhotoGalleries
    {
        public IAmazonS3 Client { get; set; }

        public IDataSource DataSource { get; set; }

        public string BucketName { get; set; }

        public static Dictionary<string, List<string>> UserPhotoDictionary = new Dictionary<string, List<string>>();

        public PhotoGallery()
        {
            Client = new AmazonS3Client(Amazon.RegionEndpoint.USEast1);
            DataSource = new MySqlDataSource();
            BucketName = ConfigurationManager.AppSettings["S3bucket"];
        }

        public async Task<bool> SavePhotosDetail(PhotosDetail photosDetail)
        {
            try
            {
                string photoKey = string.Format("{0}-{1}.jpeg", photosDetail.UserId, Guid.NewGuid());
                //string photoKey = $"{"photosDetail.UserId"}-{Guid.NewGuid()}.jpeg";

                var request = new PutObjectRequest()
                {
                    BucketName = BucketName,
                    Key = photoKey,
                    InputStream = photosDetail.Photos
                };
                PutObjectResponse response2 = Client.PutObject(request);

                photosDetail.PhotoUrl = "https://s3.amazonaws.com/" + BucketName + "/" + photoKey;
                var response = await DataSource.SavePhoto(photosDetail);
                var photoId = response.ExecutionData[KeyStore.Photo.PhotoId];
                RaisePhotoUpdatedNotification(photosDetail.UserId, photoId.ToString());
                return response.Status == KeyStore.ExecutionStatus.Success;
            }
            catch (Exception ex)
            {
                throw;
            }
            return true;
        }

        public async Task<PhotosDetailRS> GetPhotosList(PhotosDetailRQ photosDetailRQ)
        {
            var photos = await DataSource.GetPhotos(new User()
            {
                UserId = photosDetailRQ.UserId,
            });

            if (photos.Status != KeyStore.ExecutionStatus.Success || photos.Errors != null || !photos.ExecutionData.ContainsKey(KeyStore.Photo.PhotoUrls))
                return null;

            var photoUrls = photos.ExecutionData[KeyStore.Photo.PhotoUrls] as List<string>;

            if (photoUrls == null)
                return null;

            int nextPageNumber = 0;

            Int32.TryParse(photosDetailRQ.NextPageId, out nextPageNumber);

            return new PhotosDetailRS()
            {
                CollectionId = "",
                PageSize = 10,
                TotalImages = photoUrls.Count,
                Photos = await GetPhotos(photoUrls, nextPageNumber)
            };
        }

        public async Task<List<Photo>> GetPhotos(List<string> photoUrls, int nextPageNumber)
        {
            var photos = new List<Photo>();

            try
            {
                foreach (var photoUrl in photoUrls)
                {
                    photos.Add(new Photo()
                    {
                        ImageUrl = photoUrl,
                        FriendsList = null
                    });
                }

                //int numberOfPhotosToBePicked = 10;


                //int rangeEnd = (nextPageNumber + 1)* numberOfPhotosToBePicked;
                //int rangeStart = rangeEnd - numberOfPhotosToBePicked;

                //return photos.Skip(rangeStart).Take(numberOfPhotosToBePicked).ToList();
            }
            catch (Exception ex)
            {
                //supress
            }

            return photos;
        }

        private void RaisePhotoUpdatedNotification(string imageUrl, string photoId)
        {
            string accessKey = ConfigurationManager.AppSettings["AWSAccessKey"];
            string secretKey = ConfigurationManager.AppSettings["AWSSecretKey"];

            var enrollRequest = new { ImageUrl = imageUrl, PhotoId = photoId };
            using (var lambdaClient = new AmazonLambdaClient(accessKey, secretKey, RegionEndpoint.USEast1))
            {
                lambdaClient.InvokeAsync(new Amazon.Lambda.Model.InvokeAsyncRequest
                {
                    FunctionName = "RekognitionHandler",  //Move in constant or config
                    InvokeArgs = Newtonsoft.Json.JsonConvert.SerializeObject(enrollRequest),
                });
            }
        }
    }
}
