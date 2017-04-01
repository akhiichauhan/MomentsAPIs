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
        public async void SavePhotoDetail_Success()
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

        [Fact]
        public async void GetPhotos_Success()
        {
            try
            {
                PhotoGallery photoGallery = new PhotoGallery();
                await photoGallery.GetPhotos(GetUrls(13), 1);
            }
            catch (Exception ex)
            {
                Assert.False(ex.Message != null);
            }
        }

        private List<string> GetUrls(int length)
        {
            var list = new List<string>();

            for (int index = 0; index < length; index++)
            {
                list.Add(index.ToString());
            }

            return list;
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
