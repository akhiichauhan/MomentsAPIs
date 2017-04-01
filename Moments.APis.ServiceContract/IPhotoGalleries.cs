

using Moments.APIs.DataContract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Moments.APIs.ServiceContract
{
    public interface IPhotoGalleries
    {
        Task<bool> SavePhotosDetail(PhotosDetail photosDetail);

        Task<PhotosDetailRS> GetPhotosList(PhotosDetailRQ photosDetailRQ);
    }
}
