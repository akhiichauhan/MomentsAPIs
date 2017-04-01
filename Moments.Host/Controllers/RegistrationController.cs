using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using Moments.APIs.DataContract;
using Moments.APIs.ServiceContract;
using Moments.APIs.Core;

namespace Moments.Host.Controllers
{
    [RoutePrefix("api/user")]
    public class RegistrationController : ApiController
    {
        [Route("register")]
        public async Task<IHttpActionResult> SaveUserData (UserRegistrationRQ userRegistrationRQ)
        {
            if (userRegistrationRQ == null)
                throw new ArgumentNullException("userRegistrationRQ");

            IRegistration registration = new Registration();
            await registration.SaveUserData(userRegistrationRQ);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}