using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Nop.Admin.Controllers;
using Nop.Plugin.Misc.LLT.Abstracts;
using Nop.Plugin.Misc.LLT.Domain;
using Nop.Plugin.Misc.LLT.Extensions;
using Nop.Plugin.Misc.LLT.Models.Match;
using Nop.Plugin.Misc.LLT.Models.Player;
using Nop.Plugin.Misc.LLT.Models.TennisClub;
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
        private readonly ITennisClubService _tennisClubService;
        private readonly IPlayerService _playerService;
        private readonly IAddressService _addressService;

        public TournamentAdminController(ITournamentService tournamentService, ITennisClubService tennisClubService, IPlayerService playerService, IAddressService addressService)
        {
            _tournamentService = tournamentService;
            _tennisClubService = tennisClubService;
            _playerService = playerService;
            _addressService = addressService;
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

        //create
        public ActionResult Create()
        {
            var model = new TournamentDetailsModel();
            return View(model);
        }

        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        public ActionResult Create(TournamentDetailsModel model, bool continueEditing)
        {
            var tournament = model.GeneralInfo.ToEntity();
            _tournamentService.Create(tournament);
            return continueEditing ? RedirectToAction("Edit", new { id = tournament.Id }) : RedirectToAction("List");
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
            var tournamentDetails = _tournamentService.GetDetailsById(tournamentId);
            var players = tournamentDetails.Players;

            var gridModel = new DataSourceResult
            {
                Data = players,
                Total = players.Count
            };

            return Json(gridModel);
        }

        [HttpPost]
        public ActionResult PlayerInsert(int tournamentId, int? playerId)
        {
            var tournament = _tournamentService.GetById(tournamentId);
            var player = _playerService.GetById(playerId.Value);
            _tournamentService.AddPlayer(tournament, player);
            return Json(tournament);
        }

        [HttpPost]
        public ActionResult PlayerUpdate(int tournamentId, int? playerId)
        {
            var tournament = _tournamentService.GetById(tournamentId);
            var player = _playerService.GetById(playerId.Value);
            _tournamentService.UpdatePlayer(tournament, player);
            return Json(tournament);
        }

        [HttpPost]
        public ActionResult PlayerDelete(int tournamentId, int? playerId)
        {
            var tournament = _tournamentService.GetById(tournamentId);
            var player = _playerService.GetById(playerId.Value);
            _tournamentService.RemovePlayer(tournament, player);
            return Json(tournament);
        }

        [HttpPost]
        public ActionResult MatchesList(DataSourceRequest command, int tournamentId)
        {
            var tournamentDetails = _tournamentService.GetDetailsById(tournamentId);
            var matches = tournamentDetails.PlannedMatches.Concat(tournamentDetails.PlayedMatches).ToList();

            var gridModel = new DataSourceResult
            {
                Data = matches,
                Total = matches.Count
            };

            return Json(gridModel);
        }

        [HttpPost]
        public ActionResult MatchInsert(int tournamentId, int? player1Id, int? player2Id, string result)
        {
            var tournament = _tournamentService.GetById(tournamentId);

            var match = new Match();
            match.Club = Mapper.Map<TennisClubModel, TennisClub>(_tennisClubService.GetAll().First());
            match.Club.Address = _addressService.GetById(2);
            match.Player1 = _playerService.GetById(player1Id.Value);
            match.Player2 = _playerService.GetById(player2Id.Value);

            _tournamentService.AddMatch(tournament, match);
            return Json(tournament);
        }

        [HttpPost]
        public ActionResult MatchUpdate(int tournamentId, MatchModel match)
        {
            var tournament = _tournamentService.GetById(tournamentId);
            _tournamentService.UpdateMatch(tournament, match.ToEntity());
            return Json(tournament);
        }

        [HttpPost]
        public ActionResult MatchDelete(int tournamentId, MatchModel match)
        {
            var tournament = _tournamentService.GetById(tournamentId);
            _tournamentService.RemoveMatch(tournament, match.ToEntity());
            return Json(tournament);
        }
    }
}
