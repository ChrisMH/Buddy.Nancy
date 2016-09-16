using System.Collections.Generic;
using System.Text;

namespace Buddy.Nancy.Page
{
    
    public class ScriptDef
    {
        public string Src { get; set; }

        public string Type { get; set; }

        public string Body { get; set; }
    }

    public class ScriptBuilder : List<ScriptDef>
    {
        public ScriptBuilder()
        {
        }

        public ScriptBuilder(IEnumerable<ScriptDef> collection)
            : base(collection)
        {
        }
        
        public string Html
        {
            get
            {
                var strScriptBlock = new StringBuilder();

                foreach (var script in this)
                {
                    var strScript = new StringBuilder("<script");
                    if (!string.IsNullOrWhiteSpace(script.Src))
                        strScript.AppendFormat(@" src=""{0}""", script.Src);
                    if (!string.IsNullOrWhiteSpace(script.Type))
                        strScript.AppendFormat(@" type=""{0}""", script.Type);
                    strScript.AppendFormat(">{0}</script>", script.Body);

                    strScriptBlock.AppendLine(strScript.ToString());
                }

                return strScriptBlock.ToString();
            }
        }
    }
}