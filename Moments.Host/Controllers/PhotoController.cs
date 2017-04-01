using System;
using System.Threading.Tasks;
using System.Web.Http;
using Moments.APIs.Core;
using Moments.APIs.DataContract;
using Moments.APIs.ServiceContract;

namespace Moments.Host.Controllers
{
    [RoutePrefix("api/photo")]
    public class PhotoController : ApiController
    {
        [Route("save")]
        public async Task<IHttpActionResult> SavePhoto (PhotosDetail photosDetail)
        {
            if (photosDetail == null)
                throw new ArgumentNullException("photosDetail");

            IPhotoGalleries photoGalleries = new PhotoGallery();
             await photoGalleries.SavePhotosDetail(photosDetail);
            return Ok();
        }


        [Route("get")]
        public async Task<IHttpActionResult> GetPhotos(PhotosDetailRQ photosDetailRQ)
        {
            if(photosDetailRQ == null)
                throw new ArgumentNullException("photosDetailRQ");

            IPhotoGalleries photoGalleries = new PhotoGallery();
            await photoGalleries.GetPhotosList(photosDetailRQ);
            return Ok();
        }
    }
}