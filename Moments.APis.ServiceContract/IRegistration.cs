using Moments.APIs.DataContract;

namespace Moments.APIs.ServiceContract
{
    public interface IRegistration
    {
        bool SaveUserData(UserRegistrationRQ userRegistrationRQ);

        //SaveUserUpdateData.
    }
}
