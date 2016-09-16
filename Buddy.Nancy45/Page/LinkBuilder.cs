using System.Collections.Generic;
using System.Text;

namespace Buddy.Nancy.Page
{
    
    public class LinkDef
    {
        public string Rel { get; set; }

        public string Type { get; set; }

        public string Href { get; set; }
    }

    public class LinkBuilder : List<LinkDef>
    {
        public LinkBuilder()
        {
        }

        public LinkBuilder(IEnumerable<LinkDef> collection)
            : base(collection)
        {
        }
        
        public string Html
        {
            get
            {
                var strLinkBlock = new StringBuilder();

                foreach (var link in this)
                {
                    var strLink = new StringBuilder("<link");
                    if (!string.IsNullOrWhiteSpace(link.Href))
                        strLink.AppendFormat(@" href=""{0}""", link.Href);
                    if (!string.IsNullOrWhiteSpace(link.Type))
                        strLink.AppendFormat(@" type=""{0}""", link.Type);
                    if (!string.IsNullOrWhiteSpace(link.Rel))
                        strLink.AppendFormat(@" rel=""{0}""", link.Rel);
                    strLink.Append("/>");

                    strLinkBlock.AppendLine(strLink.ToString());
                }

                return strLinkBlock.ToString();
            }
        }
    }
}