using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Buddy.Nancy.Serialization
{
    public class CustomJsonSerializer : JsonSerializer
    {
        public CustomJsonSerializer()
            : this(true, true)
        {
        }

        public CustomJsonSerializer(bool camelCase)
            : this(camelCase, true)
        {
        }

        public CustomJsonSerializer(bool camelCase, bool indented)
        {
            DateFormatHandling = Newtonsoft.Json.DateFormatHandling.IsoDateFormat;
            DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc;
            MissingMemberHandling = Newtonsoft.Json.MissingMemberHandling.Ignore;

            if(camelCase)
                ContractResolver = new CamelCasePropertyNamesContractResolver();

            if (indented)
                Formatting = Newtonsoft.Json.Formatting.Indented;
        }
    }
}