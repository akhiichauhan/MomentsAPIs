using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Practices.ServiceLocation;
using Moments.APis.DataContract;
using Moments.APis.ServiceContract;
using Moments.APIs.Core;

namespace Moments.Host.Controllers
{
    [RoutePrefix("moments/register")]
    public class RegistrationController : ApiController
    {
        [Route("save")]
        public Task<bool> SaveUserData (UserRegistrationRQ userRegistrationRQ)
        {
            IRegistration registration = new Registration();
            await registration.SaveUserData(userRegistrationRQ);
            return Task.FromResult(true);
        }
    }
}