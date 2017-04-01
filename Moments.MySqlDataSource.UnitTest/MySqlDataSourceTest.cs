using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moments.APIs.DataContract;
using Moments.Data.MySqlDataSource;
using Xunit;

namespace Moments.MySqlDb.UnitTest
{
    
    public class MySqlDataSourceTest
    {
        [Fact]
        public async void CreateUserTest_Success()
        {
            try
            {
                MySqlDataSource mySqlDatabase = new MySqlDataSource();
                ExecutionResponse response = await mySqlDatabase.CreateUser(new User()
                {
                    Name = new UserName()
                    {
                        LastName = "Pawar",
                        FirstName = "Rahul",
                        MiddleName = "M"
                    },
                    Email = "meetrahul8@gmail.com",
                    Gender = Gender.Male,
                    FriendsList = new List<string>()
                    {
                        "10001",
                        "10002"
                    },
                    UserId = "100"
                });

                string personId =
                    response.ExecutionData.First(data => data.Key == KeyStore.User.PersonId).Value.ToString();
                string userId = response.ExecutionData.First(data => data.Key == KeyStore.User.UserId).Value.ToString();

                if (string.IsNullOrEmpty(personId) || string.IsNullOrEmpty(userId))
                {
                    Assert.False(1>3);
                }
                
            }
            catch (Exception ex)
            {
                Assert.False(ex.Message!=null);
            }
        }

        [Fact]
        public async void SavePhoto_Success()
        {
            try
            {
                MySqlDataSource mySqlDatabase = new MySqlDataSource();
                ExecutionResponse response = await mySqlDatabase.SavePhoto(new PhotosDetail()
                {
                    UserId = "1",
                    Name = "Rahul Pawar",
                    PhotoUrl = "https://s3.amazonaws.com/momentsfirstgallery/testFolder/Desert.jpg"
                });

            }
            catch (Exception ex)
            {
                Assert.False(ex.Message != null);
            }
        }

        [Fact]
        public async void GetPhoto_Success()
        {
            try
            {
                MySqlDataSource mySqlDatabase = new MySqlDataSource();
                ExecutionResponse response = await mySqlDatabase.GetPhotos(new User()
                {
                    UserId = "2",
                    PersonId = "1"
                });

            }
            catch (Exception ex)
            {
                Assert.False(ex.Message != null);
            }
        }

        [Fact]
        public async void SavePhotoMetadata_Success()
        {
            try
            {
                MySqlDataSource mySqlDatabase = new MySqlDataSource();
                ExecutionResponse response = await mySqlDatabase.SavePhotoMetadata(new PhotoMetadata()
                {
                    PhotoId = "2",
                    PersonIds = new List<string>() {"1"}
                });

            }
            catch (Exception ex)
            {
                Assert.False(ex.Message != null);
            }
        }
    }
}
