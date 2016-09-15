using Newtonsoft.Json;

namespace Buddy.Nancy.Serialization
{
    public class CustomJsonSerializer : JsonSerializer
    {
        public CustomJsonSerializer()
        {
            DateFormatHandling = Newtonsoft.Json.DateFormatHandling.IsoDateFormat;
            DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc;
            MissingMemberHandling = Newtonsoft.Json.MissingMemberHandling.Ignore;
        }
    }
}