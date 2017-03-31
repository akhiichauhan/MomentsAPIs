using System.Threading.Tasks;
using Moments.APIs.DataContract;

namespace Moments.APIs.ServiceContract
{
    public interface IRegistration
    {
        Task<bool> SaveUserData(UserRegistrationRQ userRegistrationRQ);

        //SaveUserUpdateData.
    }
}
