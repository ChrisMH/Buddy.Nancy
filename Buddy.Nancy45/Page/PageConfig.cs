using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using Nancy;
using Nancy.Extensions;
using Nancy.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Buddy.Nancy.Page
{
    public class PageConfig
    {
        private static readonly Regex UrlNoPathRegex = new Regex(@"^(http://|https://)[\w\.\:]+");

        public PageConfig(NancyContext context)
        {
            var originUrl = UrlNoPathRegex.Match(context.Request.Url.ToString()).Value;

            OriginUrl = string.Concat(originUrl, "/");
            RootUrl = string.Concat(originUrl, context.ToFullPath("~/"));
        }

        public string OriginUrl { get; set; }
        public string RootUrl { get; set; }

        [JsonIgnore]
        public string Json
        {
            get
            {
                var sb = new StringBuilder();
                using (var sw = new StringWriter(sb))
                {
                    using (var writer = new JsonTextWriter(sw))
                    {
                        var serializer = new JsonSerializer { ContractResolver = new CamelCasePropertyNamesContractResolver() };
                        serializer.Serialize(writer, this);
                    }
                }

                return HttpUtility.HtmlEncode(sb.ToString());
            }
        }
    }
}