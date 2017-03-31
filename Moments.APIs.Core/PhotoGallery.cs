using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moments.APIs.DataContract;
using Moments.APIs.ServiceContract;

namespace Moments.APIs.Core
{
    public class PhotoGallery : IPhotoGalleries
    {
        public Task<bool> SavePhotosDetail(PhotosDetail photosDetail)
        {
            throw new NotImplementedException();
        }

        public Task<List<PhotosDetailRS>> GetPhotosList(PhotosDetailRQ photosDetailRQ)
        {
            throw new NotImplementedException();
        }
    }
}
