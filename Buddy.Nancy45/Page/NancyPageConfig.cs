using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using Buddy.Web;
using Nancy;
using Nancy.Extensions;
using Nancy.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Buddy.Nancy.Page
{
    public class NancyPageConfig : PageConfig
    {
        private static readonly Regex UrlNoPathRegex = new Regex(@"^(http://|https://)[\w\.\:]+");

        public NancyPageConfig(NancyContext context, Assembly versionAssembly, bool debug)
            : base("", "", versionAssembly, debug)
        {
            var originUrl = UrlNoPathRegex.Match(context.Request.Url.ToString()).Value;

            OriginUrl = string.Concat(originUrl, "/");
            RootUrl = string.Concat(originUrl, context.ToFullPath("~/"));
        }
        
    }
}