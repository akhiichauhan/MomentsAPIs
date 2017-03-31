using Moments.APis.DataContract;

namespace Moments.APis.ServiceContract
{
    interface IRegistration
    {
        bool SaveUserData(UserRegistrationRQ userRegistrationRQ);

        //SaveUserUpdateData.
    }
}
