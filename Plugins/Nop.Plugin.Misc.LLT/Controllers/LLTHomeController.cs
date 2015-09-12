using System.Web.Mvc;
using Nop.Web.Framework.Controllers;

namespace Nop.Plugin.Misc.LLT.Controllers
{
    public class LLTHomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
