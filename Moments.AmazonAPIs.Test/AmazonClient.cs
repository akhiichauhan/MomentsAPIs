using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using System.IO;

namespace Moments.AmazonAPIs.Test
{
    public class AmazonClient
    {
        public Dictionary<string, string> GetHeaders()
        {
            var headers = new Dictionary<string, string>
            {
                { "Host","rekognition.us-west-2.amazonaws.com" },
                { "Accept-Encoding","identity" },
                //{ "Content-Length","278" },
                { "X-Amz-Target","RekognitionService.CompareFaces" },
                { "X-Amz-Date",GetCurrentDate1()+"Z" },
                { "User-Agent","aws-cli/1.11.25 Python/2.7.9 Windows/8 botocore/1.4.82" },
                { "Content-Type","application/x-amz-json-1.1" },
                
            };

            return headers;

        }

        private string GetCurrentDate1()
        {
            return DateTime.UtcNow.ToString("yyyyMMddTHHmmss");
        }

        private string GetCurrentDate2()
        {
            return DateTime.UtcNow.ToString("yyyyMMdd");
        }

        public WebClient GetClient(string request)
        {
            WebClient client = new WebClient();

            foreach (var header in GetHeaders())
            {
                client.Headers.Add(header.Key,header.Value);
            }

            return client;
            
        }
        
    }
}
