using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moments.APIs.Core;
using Moments.APIs.DataContract;
using Moments.APIs.ServiceContract;
using Xunit;

namespace Moments.UnitTest
{
    public class PhotoGalleryUnitTest
    {
        [Fact]
        public async void SavePhotoMetadata_Success()
        {
            try
            {
                IPhotoGalleries photoGalleries = new PhotoGallery();
                await photoGalleries.SavePhotosDetail(GetPhotoDetail());
            }
            catch (Exception ex)
            {
                Assert.False(ex.Message != null);
            }
        }

        private PhotosDetail GetPhotoDetail()
        {
            return new PhotosDetail()
            {
                Photos = new FileStream(@"C:\Users\Public\Pictures\Sample Pictures\Koala.jpg", FileMode.Open),
                UserId = "100",
        };

        }
    }
}
