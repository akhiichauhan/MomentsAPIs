using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moments.APIs.DataContract
{
    public class KeyStore
    {
        public class ExecutionStatus
        {
            public static readonly string Success = "success";
            public static readonly string Failure = "failure";
        }

        public class ErrorMessages
        {
            public static readonly string UserCreationFailure = "Failed to create user in database.";
            public static readonly string PhotoSaveFailure = "Failed to save photo in database.";
            public static readonly string PhotoTagSaveFailure = "Failed to save photo tags in database.";
            public static readonly string PhotoRetrievalFailure = "Failed to get photos from database.";
        }

        public class User
        {
            public static readonly string UserId="userid";
            public static readonly string PersonId = "personid";
        }

        public class Photo
        {
            public static readonly string PhotoId = "photoid";
            public static readonly string PhotoUrls = "photourls";
        }
    }
}
