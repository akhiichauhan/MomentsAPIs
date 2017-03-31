using System.Collections.Generic;

namespace Moments.APIs.DataContract
{
    public class PhotosDetailRS
    {
        public int TotalImages { get; set; }
        public int PageSize { get; set; } //default will be 10
        public string ImageUrl { get; set; }
        public List<string> FriendsList { get; set; }
        public string CollectionId { get; set; }
      }
}