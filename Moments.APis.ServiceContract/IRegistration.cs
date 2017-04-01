using System.Threading.Tasks;
using Moments.APIs.DataContract;

namespace Moments.APIs.ServiceContract
{
    public interface IRegistration
    {
        Task<ExecutionResponse> SaveUserData(UserRegistrationRQ userRegistrationRQ);

        //SaveUserUpdateData.
    }
}
