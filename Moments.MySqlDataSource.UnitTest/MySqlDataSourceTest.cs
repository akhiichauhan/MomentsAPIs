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

            MySqlDataSource mySqlDatabase = new MySqlDataSource();
            ExecutionResponse response = await mySqlDatabase.CreateUser(new User()
            {
                Email = "meetrahul8@gmail.com",
                Gender = Gender.Male,
                FriendsList = new List<string>()
                {
                    "10001",
                    "10002"
                },
            });

            string personId = response.ExecutionData.First(data => data.Key == KeyStore.User.PersonId).Value.ToString();
            string userId = response.ExecutionData.First(data => data.Key == KeyStore.User.UserId).Value.ToString();

            Assert.True(string.IsNullOrEmpty(personId));
            Assert.True(string.IsNullOrEmpty(userId));
        }
    }
}
