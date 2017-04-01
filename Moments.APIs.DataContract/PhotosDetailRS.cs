using System.Collections.Generic;

namespace Moments.APIs.DataContract
{
    public class PhotosDetailRS
    {
        public int TotalImages { get; set; }
        public int PageSize { get; set; } //default will be 10
        public List<Photo> Photos { get; set; }
        public string CollectionId { get; set; }
      }

    public class Photo
    {
        public string ImageUrl { get; set; }
        public List<string> FriendsList { get; set; }
    }
}