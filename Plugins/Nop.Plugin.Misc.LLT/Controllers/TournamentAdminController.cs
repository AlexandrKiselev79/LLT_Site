using System.Linq;
using System.Web.Mvc;
using Nop.Admin.Controllers;
using Nop.Plugin.Misc.LLT.Abstracts;
using Nop.Plugin.Misc.LLT.Extensions;
using Nop.Plugin.Misc.LLT.Models.Player;
using Nop.Plugin.Misc.LLT.Models.Tournament;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Kendoui;
using Nop.Web.Framework.Mvc;

namespace Nop.Plugin.Misc.LLT.Controllers
{
    [AdminAuthorize]
    public class TournamentAdminController : BaseAdminController
    {
        private readonly ITournamentService _tournamentService;

        public TournamentAdminController(ITournamentService tournamentService)
        {
            _tournamentService = tournamentService;
        }

        //list
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            return View();
        }

        [HttpPost]
        public ActionResult List(TournamentListModel model, DataSourceRequest command)
        {
            var tournaments = _tournamentService.GetAll(model.SearchType, model.SearchName).Select(x => x.ToModel()).ToList();
            
            var gridModel = new DataSourceResult
            {
                Data = tournaments.PagedForCommand(command).Select(x => x),
                Total = tournaments.Count
            };

            return Json(gridModel);
        }

        //edit
        public ActionResult Edit(int id)
        {
            var tournament = _tournamentService.GetDetailsById(id);
            if (tournament == null)
                return RedirectToAction("List");

            return View(tournament);
        }

        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        public ActionResult Edit(TournamentDetailsModel model, bool continueEditing)
        {
            var tournament = _tournamentService.GetById(model.GeneralInfo.Id);
            if (tournament == null)
                return RedirectToAction("List");

            //tournament = model.ToEntity();
            //_tournamentService.Update(tournament);

            if (continueEditing)
            {
                return RedirectToAction("Edit", new { id = model.GeneralInfo.Id });
            }
            return RedirectToAction("List");
        }

        [HttpPost]
        public ActionResult PlayersList(DataSourceRequest command, int tournamentId)
        {
            var tournament = _tournamentService.GetDetailsById(tournamentId);
            var players = tournament.Players;
            
            var gridModel = new DataSourceResult
            {
                Data = players,
                Total = players.Count
            };

            return Json(gridModel);
        }

        [HttpPost]
        public ActionResult PlayerInsert(PlayerModel model)
        {
            return new NullJsonResult();
        }

        [HttpPost]
        public ActionResult PlayerDelete(int id)
        {
            return new NullJsonResult();
        }
    }
}
