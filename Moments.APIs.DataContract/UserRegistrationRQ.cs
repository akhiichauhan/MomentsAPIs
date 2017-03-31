using System.Collections.Generic;

namespace Moments.APis.DataContract
{
    public class UserRegistrationRQ
    {
        public string UserId { get; set; }
        public UserName UserName { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }
        public string ProfilePic { get; set; }
        public List<string> FriendsList { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }
}