using System;
using System.IO;
using System.Net;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace Moments.Host
{
    public class JsonNetTextFormatter : MediaTypeFormatter
    {
        public JsonNetTextFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));
        }

        public override bool CanReadType(Type type)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            return true;
        }

        public override bool CanWriteType(Type type)
        {
            // don't serialize JsonValue structure use default for that
            if (type == typeof(JValue) || type == typeof(JObject) || type == typeof(JArray))
                return false;

            return true;
        }


        public override Task<object> ReadFromStreamAsync(Type type, Stream readStream,
            System.Net.Http.HttpContent content, IFormatterLogger formatterLogger)
        {
            using (var profileContext = new ProfileContext("Pre Controller - Deserializer"))
            {
                var tcs = new TaskCompletionSource<object>();
                //todo convert Stream to byte is alternate option rather than using Memory Stream - need to have comparission in place
                using (var memoryStream = new MemoryStream())
                {
                    readStream.CopyTo(memoryStream);
                    var json = System.Text.Encoding.UTF8.GetString(memoryStream.ToArray());
                    var output = JsonConvert.DeserializeObject(json, type);
                    tcs.SetResult(output);
                }
                return tcs.Task;
            }
        }

        public override Task WriteToStreamAsync(Type type, object value, Stream writeStream,
            System.Net.Http.HttpContent content, TransportContext transportContext)
        {
            var task = Task.Factory.StartNew(() =>
            {
                string json = JsonConvert.SerializeObject(value, Formatting.Indented,
                                                          new JsonConverter[1] { new IsoDateTimeConverter() });
                byte[] buf = System.Text.Encoding.Default.GetBytes(json);
                writeStream.Write(buf, 0, buf.Length);
                writeStream.Flush();
            });

            return task;
        }
    }
}