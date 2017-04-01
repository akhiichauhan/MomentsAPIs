using System;
using System.Threading.Tasks;
using Moments.APIs.DataContract;
using Moments.APIs.ServiceContract;
using Moments.Data.MySqlDataSource;

namespace Moments.APIs.Core
{
    public class Registration : IRegistration
    {
        public IDataSource DataSource { get; set; }

        public Registration()
        {
            DataSource = new MySqlDataSource();
        }
        public async Task<bool> SaveUserData(UserRegistrationRQ userRegistrationRQ)
        {
            await DataSource.CreateUser(userRegistrationRQ.User);
            return true;
        }
    }
}
