using System;
using System.Threading.Tasks;
using Moments.APIs.DataContract;
using Moments.APIs.ServiceContract;

namespace Moments.APIs.Core
{
    public class Registration : IRegistration
    {
        public async Task<bool> SaveUserData(UserRegistrationRQ userRegistrationRQ)
        {
            throw new NotImplementedException();
        }
    }
}
