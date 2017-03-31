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
        //Create User -

        Task<ExecutionResponse> CreateUser(User user);

        //Save Photo
        Task<ExecutionResponse> SavePhoto(PhotosDetail photoDetails);

        //GetUserPhotos
        Task<ExecutionResponse> GetPhotos(User user);


        //SavePhotoMetaData
        Task<ExecutionResponse> SavePhotoMetadata(PhotoMetadata user);
    }
}
