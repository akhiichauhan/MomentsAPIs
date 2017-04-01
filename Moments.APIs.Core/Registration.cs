using System;
using System.Threading.Tasks;
using Moments.APIs.DataContract;
using Moments.APIs.ServiceContract;
using Moments.Data.MySqlDataSource;
using System.Configuration;
using Amazon.Lambda;
using Amazon;

namespace Moments.APIs.Core
{
    public class Registration : IRegistration
    {
        public IDataSource DataSource { get; set; }

        public Registration()
        {
            DataSource = new MySqlDataSource();
        }
        public async Task<bool> SaveUserData(UserRegistrationRQ userRegistrationRQ)
        {
            await DataSource.CreateUser(userRegistrationRQ.User);
            RaisePhotoUpdatedNotification(userRegistrationRQ.User.UserId, userRegistrationRQ.User.ProfilePic);
            return true;
        }
        private void RaisePhotoUpdatedNotification(string imageUrl, string userId)
        {
            string accessKey = ConfigurationManager.AppSettings["AWSAccessKey"];
            string secretKey = ConfigurationManager.AppSettings["AWSSecretKey"];

            var enrollRequest = new { ImageUrl = imageUrl, UserId = userId };
            using (var lambdaClient = new AmazonLambdaClient(accessKey, secretKey, RegionEndpoint.USEast1))
            {
                lambdaClient.InvokeAsync(new Amazon.Lambda.Model.InvokeAsyncRequest
                {
                    FunctionName = "arn:EnrollHandler",  //Move in constant or config
                    InvokeArgs =  Newtonsoft.Json.JsonConvert.SerializeObject(enrollRequest),
                });
            }
        }
    }
}
