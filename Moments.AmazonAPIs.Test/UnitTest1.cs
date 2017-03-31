using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Script.Serialization;
using System.Net.Http;
using System.Net;
using System.IO;

namespace Moments.AmazonAPIs.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAmazonFareRekognitionAPI()
        {
            string url = "https://rekognition.us-west-2.amazonaws.com/";
            var request = GetRequest();
            var client = new AmazonClient().GetClient(request);

            var response = client.UploadString(url, request);

            //using (Stream data = client.OpenRead(url))
            //{
            //    using (StreamReader reader = new StreamReader(data))
            //    {
            //        string s = reader.ReadToEnd();
            //        reader.Close();
            //    }
            //    data.Close();
            //}

        }

        private string GetRequest()
        {
            var data = System.IO.File.ReadAllText(@"Json.txt");

            //JavaScriptSerializer serializer = new JavaScriptSerializer();
            //var request = serializer.DeserializeObject<Rootobject>(data);

            return data;
        }
    }
}
