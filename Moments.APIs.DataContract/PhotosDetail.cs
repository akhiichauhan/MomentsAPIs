using System;
using System.IO;

namespace Moments.APIs.DataContract
{
    public class PhotosDetail
    {
        public string UserId { get; set; }
        public Stream Photos { get; set; }

        public string PhotoUrl { get; set; }

        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime TimeStamp { get; set; }

    }
}