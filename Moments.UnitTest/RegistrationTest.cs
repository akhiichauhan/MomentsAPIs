using Moments.APIs.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moments.APIs.DataContract;

namespace Moments.UnitTest
{
    public class RegistrationTest
    {
        [Fact]
        public async void TestCoreRegistrationAPI()
        {
            var registration = new Registration();
            var response = await registration.SaveUserData(GetUserRequest());
        }

        private UserRegistrationRQ GetUserRequest()
        {
            return new UserRegistrationRQ()
            {
                User = new User()
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
                    UserId = "100",
                    ProfilePic = "http://starsunfolded.1ygkv60km.netdna-cdn.com/wp-content/uploads/2013/08/hrithik-roshan1.jpg"
                },
            };
        }
    }
}
