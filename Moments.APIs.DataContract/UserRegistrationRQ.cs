using System.Collections.Generic;
using Moments.APIs.DataContract;

namespace Moments.APIs.DataContract
{
    public class UserRegistrationRQ
    {
        public User User { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }
}