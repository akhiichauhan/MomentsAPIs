using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Moments.APIs.Core;
using Moments.APIs.DataContract;
using Moments.APIs.ServiceContract;
using Moments.Data.MySqlDataSource;

namespace Moments.Host.Controllers
{
    [RoutePrefix("moments/api/datasource")]
    public class DataSourceController: ApiController
    {
        [Route("savephotometadata")]
        public async Task<IHttpActionResult> SavePhotoMetadata(PhotoMetadata photoMetadata)
        {
            IDataSource dataSource = new MySqlDataSource();
            await dataSource.SavePhotoMetadata(photoMetadata);
            return Ok();
        }
    }
}