using System.Web.Mvc;
using Nop.Plugin.Misc.LLT.Abstracts;
using Nop.Plugin.Misc.LLT.Models.TennisClub;
using Nop.Web.Framework.Controllers;

namespace Nop.Plugin.Misc.LLT.Controllers
{
    public class ClubController : BasePluginController
    {
        private readonly ITennisClubService _tennisClubService;

        public ClubController(ITennisClubService tennisClubService)
        {
            _tennisClubService = tennisClubService;
        }

        public ActionResult List()
        {
            var model = new TennisClubListModel
            {
                Clubs = _tennisClubService.GetAll()
            };
            return View(model);
        }

        public ActionResult Club(int clubId)
        {
            var model = _tennisClubService.GetById(clubId);
            return View(model);
        }
    }
}
