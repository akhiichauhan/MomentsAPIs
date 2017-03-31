using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moments.APIs.DataContract
{
    public class ExecutionResponse
    {
        public ExecutionResponse()
        {
            Status = KeyStore.ExecutionStatus.Success;
            ExecutionData= new Dictionary<string, object>();
            Errors= new List<string>();
        }

        public string Status { get; set; }

        public Dictionary<string,object> ExecutionData { get; set; }

        public List<string> Errors { get; set; }
    }
}
