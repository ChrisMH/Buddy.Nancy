using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Buddy.Nancy.Serialization
{
    public class CustomJsonSerializer : JsonSerializer
    {
        public CustomJsonSerializer(bool camelCase = true, bool indented = true)
        {
            DateFormatHandling = Newtonsoft.Json.DateFormatHandling.IsoDateFormat;
            DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc;
            MissingMemberHandling = Newtonsoft.Json.MissingMemberHandling.Ignore;

            if(camelCase)
                ContractResolver = new CamelCasePropertyNamesContractResolver();

            if (indented)
                Formatting = Formatting.Indented;
        }
    }
}