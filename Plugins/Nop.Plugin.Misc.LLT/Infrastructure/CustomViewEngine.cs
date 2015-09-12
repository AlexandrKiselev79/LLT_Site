using Nop.Web.Framework.Themes;

namespace Nop.Plugin.Misc.LLT.Infrastructure
{
    public class CustomViewEngine : ThemeableRazorViewEngine
    {
        public CustomViewEngine()
        {
            ViewLocationFormats = new[] { "~/Plugins/Misc.LLT/Views/{0}.cshtml" };
            PartialViewLocationFormats = new[] { "~/Plugins/Misc.LLT/Views/{0}.cshtml" };
        }
    }
}
