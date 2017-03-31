
namespace Moments.AmazonAPIs.Test
{
    public class Rootobject
    {
        public Targetimage TargetImage { get; set; }
        public Sourceimage SourceImage { get; set; }
    }

    public class Targetimage
    {
        public S3object S3Object { get; set; }
    }

    public class S3object
    {
        public string Bucket { get; set; }
        public string Name { get; set; }
    }

    public class Sourceimage
    {
        public S3object1 S3Object { get; set; }
    }

    public class S3object1
    {
        public string Bucket { get; set; }
        public string Name { get; set; }
    }
}
