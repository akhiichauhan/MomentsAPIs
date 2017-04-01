using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;
using Amazon.S3;
using Amazon.S3.Model;
using Moments.APIs.DataContract;
using Moments.APIs.ServiceContract;
using Moments.Data.MySqlDataSource;

namespace Moments.APIs.Core
{
    public class PhotoGallery : IPhotoGalleries
    {
        public IAmazonS3 Client { get; set; }

        public IDataSource DataSource { get; set; }

        public string BucketName { get; set; }

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

                photosDetail.PhotoUrl = "https://s3.amazonaws.com/" + BucketName +"/" + photoKey;
                await DataSource.SavePhoto(photosDetail);
            }
            catch (Exception ex)
            {
                throw;
            }
            return true;
        }

        public async Task<List<PhotosDetailRS>> GetPhotosList(PhotosDetailRQ photosDetailRQ)
        {
            var photos = await DataSource.GetPhotos(new User()
            {
                UserId = photosDetailRQ.UserId,
                //Email = ,
                //FriendsList = ,
                //Gender = ,
                //Name = ,
                //PersonId = ,
                //ProfilePic = 
            });

            var photoDetails = new List<PhotosDetailRS>();

            var photoUrls =  photos.ExecutionData[KeyStore.Photo.PhotoUrls];

            return new List<PhotosDetailRS>()
            {
                new PhotosDetailRS()
                {
                    FriendsList = null,
                    CollectionId = "",
                    ImageUrl = "",
                    PageSize = 0,
                    TotalImages = 0
                }
            };
        }


        //public static Stream GenerateStreamFromString(string s)
        //{
        //    MemoryStream stream = new MemoryStream();
        //    StreamWriter writer = new StreamWriter(stream);
        //    writer.Write(s);
        //    writer.Flush();
        //    stream.Position = 0;
        //    return stream;
        //}

    }
}
