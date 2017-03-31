using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moments.APIs.DataContract
{
    public class PhotoMetadata
    {
        public string PhotoId { get; set; }
        public List<string> PersonIds { get; set; }
    }
}
