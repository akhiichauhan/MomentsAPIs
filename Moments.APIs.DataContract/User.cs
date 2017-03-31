using System.Collections.Generic;

namespace Moments.APIs.DataContract
{
    public class User
    {
        public string UserId { get; set; }
        public UserName UserName { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }
        public string ProfilePic { get; set; }
        public List<string> FriendsList { get; set; }
    }
}
