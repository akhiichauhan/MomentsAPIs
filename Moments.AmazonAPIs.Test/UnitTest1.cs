using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Script.Serialization;
using System.Net.Http;
using System.Net;
using System.IO;
using Amazon.Rekognition.Model.Internal.MarshallTransformations;
using Amazon.Rekognition.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.Rekognition;
using Amazon;

namespace Moments.AmazonAPIs.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAmazonFaceRekognitionAPI()
        {
            //string url = "https://rekognition.us-west-2.amazonaws.com/";
            //var request = GetRequest();
            //var client = new AmazonClient().GetClient(request);

            //var response = client.UploadString(url, request);

            TestFaceCompareAPIs();
            //TestFaceDetectAPIs();

        }


        public  void TestFaceCompareAPIs()
        {
            try
            {
                string awsAccessKey = "AKIAJ325ZADNS2SMMCQA";
                string awsSecretKey = "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";

                using (var client = new Amazon.Rekognition.AmazonRekognitionClient(awsAccessKey, awsSecretKey, RegionEndpoint.USEast1))
                {
                   var createCollectionResponse= client.CreateCollection(new CreateCollectionRequest()
                    {
                        CollectionId = "c101"
                    });

                   

                    if (createCollectionResponse.HttpStatusCode == HttpStatusCode.OK)
                    {

                        var indexFacesResponse = client.IndexFaces(new IndexFacesRequest()
                        {
                            CollectionId = "c101",
                            ExternalImageId = "TestImage1",
                            Image = new Image()
                            {
                                S3Object = new Amazon.Rekognition.Model.S3Object()
                                {
                                    Bucket = "momentsfirstgallery",
                                    Name = "100-28bf0b60-9b65-4e80-9b40-ed55bab15c52.jpeg"
                                }
                            }
                        });


                        var indexFacesResponse2 = client.IndexFaces(new IndexFacesRequest()
                        {
                            CollectionId = "c101",
                            ExternalImageId = "TestImage2",
                            Image = new Image()
                            {
                                S3Object = new Amazon.Rekognition.Model.S3Object()
                                {
                                    Bucket = "momentsfirstgallery",
                                    Name = "100-39c76e1e-8bc5-4252-822c-42454db88bc4.jpeg"
                                }
                            }
                        });


                        var response = client.CompareFaces(GetCompareFaceRequest());

                        List<CompareFacesMatch> faceMatches = response.FaceMatches;
                        ComparedSourceImageFace sourceImageFace = response.SourceImageFace;
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        public void TestFaceDetectAPIs()
        {
            string awsAccessKey = ""; 
            string awsSecretKey = "";


            using (var client = new Amazon.Rekognition.AmazonRekognitionClient(awsAccessKey, awsSecretKey, new AmazonRekognitionConfig()
            {
                LogMetrics = true,
                LogResponse = true,
                RegionEndpoint = RegionEndpoint.USEast1
            }))
            {
                var response = client.DetectFaces(GetDetectFaceRequest());//.CompareFaces(GetCompareFaceRequest());

                
            }
        }

        private DetectFacesRequest GetDetectFaceRequest()
        {
            return new DetectFacesRequest
            {
                Image = new Image
                {
                    S3Object = new Amazon.Rekognition.Model.S3Object()
                    {
                        Bucket = "momentsfirstgallery",
                        Name = "100-28bf0b60-9b65-4e80-9b40-ed55bab15c52.jpeg"
                    },
                },
                Attributes =new List<string> { },
            };
        }

        public Amazon.Rekognition.Model.CompareFacesRequest GetCompareFaceRequest()
        {
            return new Amazon.Rekognition.Model.CompareFacesRequest()
            {
                //SimilarityThreshold=90,
                
                TargetImage = new Amazon.Rekognition.Model.Image()
                {
                    S3Object = new Amazon.Rekognition.Model.S3Object()
                    {
                        Bucket = "momentsfirstgallery",
                        Name = "100-28bf0b60-9b65-4e80-9b40-ed55bab15c52.jpeg"
                    }
                },
                SourceImage = new Amazon.Rekognition.Model.Image
                {
                    //Bytes=
                    S3Object = new Amazon.Rekognition.Model.S3Object
                    {
                        Bucket = "momentsfirstgallery",
                        Name= "100-39c76e1e-8bc5-4252-822c-42454db88bc4.jpeg",
                    },
                },
                             
                
            };
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
