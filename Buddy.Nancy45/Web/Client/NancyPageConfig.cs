using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using Nancy;
using Nancy.Extensions;
using Nancy.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Buddy.Web.Client;

namespace Buddy.Nancy.Web.Client
{
    public class NancyPageConfig : PageConfig
    {
        private static readonly Regex UrlNoPathRegex = new Regex(@"^(http://|https://)[\w\.\:]+");

        public NancyPageConfig(NancyContext context, Assembly versionAssembly)
        {            

            var originUrl = UrlNoPathRegex.Match(context.Request.Url.ToString()).Value;

            OriginUrl = string.Concat(originUrl, "/");
            RootUrl = string.Concat(originUrl, context.ToFullPath("~/"));
            if (versionAssembly != null)
            {
                var version = versionAssembly.GetName().Version.ToString();
                Version = version.Substring(0, version.LastIndexOf('.'));
            }
        }        
    }
}