using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using Moments.APIs.DataContract;
using Moments.APIs.ServiceContract;
using Moments.APIs.Core;

namespace Moments.Host.Controllers
{
    [RoutePrefix("moments/register")]
    public class RegistrationController : ApiController
    {
        [Route("save")]
        public async Task<IHttpActionResult> SaveUserData (UserRegistrationRQ userRegistrationRQ)
        {
            IRegistration registration = new Registration();
            await registration.SaveUserData(userRegistrationRQ);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}