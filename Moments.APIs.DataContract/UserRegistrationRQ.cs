using System.Collections.Generic;
using Moments.APIs.DataContract;

namespace Moments.APIs.DataContract
{
    public class UserRegistrationRQ
    {
        private User User { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }
}