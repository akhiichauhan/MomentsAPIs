using System;
using System.Configuration;
using System.Threading.Tasks;
using Amazon.Lambda;
using Amazon.Runtime;
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
        public async Task<ExecutionResponse> SaveUserData(UserRegistrationRQ userRegistrationRQ)
        {
           var response= await DataSource.CreateUser(userRegistrationRQ.User);
            RaisePhotoUpdatedNotification(userRegistrationRQ.User.UserId, userRegistrationRQ.User.ProfilePic);
            return response;
        }
        private void RaisePhotoUpdatedNotification(string userId, string imageUrl)
        {
            try
            {

                string accessKey = ConfigurationManager.AppSettings["AWSAccessKey"];
                string secretKey = ConfigurationManager.AppSettings["AWSSecretKey"];

                var enrollRequest = new {ImageUrl = imageUrl, UserId = userId};
                using (var lambdaClient = new AmazonLambdaClient(accessKey, secretKey, RegionEndpoint.USEast1))
                {
                    var response = lambdaClient.InvokeAsync(new Amazon.Lambda.Model.InvokeAsyncRequest
                    {
                        FunctionName = "EnrollHandler", //Move in constant or config
                        InvokeArgs = Newtonsoft.Json.JsonConvert.SerializeObject(enrollRequest),
                    });
                }
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}
