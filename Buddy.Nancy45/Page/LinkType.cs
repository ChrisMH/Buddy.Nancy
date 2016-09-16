using System.ComponentModel;

namespace Buddy.Nancy.Page
{
    public enum LinkType
    {
        [Description("text/javascript")]
        None,

        [Description("text/css")]
        Css
    }
}