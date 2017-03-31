using Moments.APis.DataContract;

namespace Moments.APis.ServiceContract
{
    public interface IRegistration
    {
        bool SaveUserData(UserRegistrationRQ userRegistrationRQ);

        //SaveUserUpdateData.
    }
}
