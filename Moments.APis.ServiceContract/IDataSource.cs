using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moments.APIs.DataContract;

namespace Moments.APIs.ServiceContract
{
    public interface IDataSource
    {
        Task<ExecutionResponse> CreateUser(User user);

        Task<ExecutionResponse> SavePhoto(PhotosDetail photoDetails);

        Task<ExecutionResponse> GetPhotos(User user);

        Task<ExecutionResponse> SavePhotoMetadata(PhotoMetadata photoMetadata);
    }
}
