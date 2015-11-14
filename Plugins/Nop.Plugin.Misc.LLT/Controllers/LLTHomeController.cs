using System.Web.Mvc;
using Nop.Core.Data;
using Nop.Plugin.Misc.LLT.Domain;
using Nop.Web.Framework.Controllers;

namespace Nop.Plugin.Misc.LLT.Controllers
{
    public class LLTHomeController : BaseController
    {
        private IRepository<Match> _matchesRepository;
        
        public LLTHomeController(IRepository<Match> matchesRepository)
        {
            _matchesRepository = matchesRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Regulations()
        {
            return View();
        }

        public ActionResult Rating()
        {
            return View();
        }

        public ActionResult Courts()
        {
            return View();
        }
    }
}
