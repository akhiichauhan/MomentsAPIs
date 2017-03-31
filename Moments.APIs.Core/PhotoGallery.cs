using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moments.APis.DataContract;
using Moments.APis.ServiceContract;
using Moments.APIs.DataContract;
using Moments.APIs.ServiceContract;

namespace Moments.APIs.Core
{
    public class PhotoGallery : IPhotoGalleries
    {
        public bool SavePhotosDetail(PhotosDetail photosDetail)
        {
            throw new NotImplementedException();
        }

        public List<PhotosDetailRS> GetPhotosList(PhotosDetailRQ PhotosDetailRQ)
        {
            throw new NotImplementedException();
        }
    }
}
