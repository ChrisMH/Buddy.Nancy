using System.ComponentModel;

namespace Buddy.Nancy.Page
{
    public enum LinkRelType
    {
        [Description("text/javascript")]
        None,

        [Description("stylesheet")]
        Stylesheet
    }
}