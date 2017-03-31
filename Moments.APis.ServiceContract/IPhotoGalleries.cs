

using Moments.APIs.DataContract;
using System.Collections.Generic;

namespace Moments.APIs.ServiceContract
{
    interface IPhotoGalleries
    {
        bool SavePhotosDetail(PhotosDetail photosDetail);

        List<PhotosDetailRS> GetPhotosList(PhotosDetailRQ PhotosDetailRQ);
    }
}
