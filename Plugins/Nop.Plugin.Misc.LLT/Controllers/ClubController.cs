using System.Web.Mvc;
using Nop.Web.Framework.Controllers;

namespace Nop.Plugin.Misc.LLT.Controllers
{
    public class ClubController : BasePluginController
    {
        public ClubController()
        {
            
        }

        public ActionResult List()
        {
            return View();
        }

        public ActionResult ClubItem()
        {
            return View();
        }
    }
}
