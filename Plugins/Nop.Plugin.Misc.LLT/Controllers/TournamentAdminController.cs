using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Nop.Admin.Controllers;
using Nop.Plugin.Misc.LLT.Abstracts;
using Nop.Plugin.Misc.LLT.Domain;
using Nop.Plugin.Misc.LLT.Enums;
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

        [HttpPost]
        public ActionResult Delete(int tournamentId)
        {
            var tournament = _tournamentService.GetById(tournamentId);
            if (tournament == null)
                return Json(null);
            else
            {
                tournament.Deleted = true;
                _tournamentService.Update(tournament);
                return Json(tournament);
            }
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
        public ActionResult ResultsList(DataSourceRequest command, int tournamentId)
        {
            var tournamentDetails = _tournamentService.GetDetailsById(tournamentId);
            var matches = tournamentDetails.PlayedMatches.ToList();

            var gridModel = new DataSourceResult
            {
                Data = matches,
                Total = matches.Count
            };

            return Json(gridModel);
        }

        [HttpPost]
        public ActionResult MatchesList(DataSourceRequest command, int tournamentId)
        {
            var tournamentDetails = _tournamentService.GetDetailsById(tournamentId);
            var matches = tournamentDetails.PlannedMatches.ToList();

            var gridModel = new DataSourceResult
            {
                Data = matches,
                Total = matches.Count
            };

            return Json(gridModel);
        }

        [HttpPost]
        public ActionResult MatchInsert(int tournamentId, MatchModel match)
        {
            var tournament = _tournamentService.GetById(tournamentId);

            var newMatch = new Match();
            newMatch.Club = _tennisClubService.GetById(3);// Mapper.Map<TennisClubModel, TennisClub>(_tennisClubService.GetAll().First());
            newMatch.Club.Address = _addressService.GetById(2);
            newMatch.Player1 = _playerService.GetById(match.Player1.Id);
            newMatch.Player2 = _playerService.GetById(match.Player2.Id);
            newMatch.Stage = match.Stage;

            ParseMatchResult(newMatch, match.MatchResultDisplay);

            _tournamentService.AddMatch(tournament, newMatch);
            return Json(tournament);
        }

        [HttpPost]
        public ActionResult MatchUpdate(int tournamentId, MatchModel match)
        {
            var tournament = _tournamentService.GetById(tournamentId);
            var updatedMatch = _tournamentService.GetMatchById(tournamentId, match.Id);
            updatedMatch.Player1 = _playerService.GetById(match.Player1.Id);
            updatedMatch.Player2 = _playerService.GetById(match.Player2.Id);
            updatedMatch.Stage = match.Stage;

            ParseMatchResult(updatedMatch, match.MatchResultDisplay);

            _tournamentService.UpdateMatch(tournament, updatedMatch);
            return Json(tournament);
        }

        [HttpPost]
        public ActionResult MatchDelete(int tournamentId, int? matchId)
        {
            var tournament = _tournamentService.GetById(tournamentId);
            var match = _tournamentService.GetMatchById(tournamentId, matchId.Value);
            match.Deleted = true;

            _tournamentService.UpdateMatch(tournament, match);
            return Json(tournament);
        }

        [HttpPost]
        public ActionResult MatchComplete(int tournamentId, MatchModel match)
        {
            var tournament = _tournamentService.GetById(tournamentId);
            var updatedMatch = _tournamentService.GetMatchById(tournamentId, match.Id);
            updatedMatch.CompletionReason = match.CompletionReason;
            updatedMatch.WinnerId = match.WinnerId;

            _tournamentService.UpdateMatch(tournament, updatedMatch);
            return Json(tournament);
        }

        private void ParseMatchResult(Match match, string result)
        {
            if (string.IsNullOrEmpty(result))
            {
                return;
            }

            var setResults = new List<SetResult>();

            var sets = result.Trim().Split(' ');
            for (var i = 0; i < sets.Length; i++)
            {
                var set = sets[i];

                var setResult = new SetResult();
                if (set.Contains('-') && set.Split(new[] { "-" }, StringSplitOptions.RemoveEmptyEntries).Length == 2)
                {
                    setResult.Number = i + 1;
                    setResult.Player1 = match.Player1;
                    setResult.Player2 = match.Player2;
                    setResult.Player1Games = int.Parse(set.Split('-')[0]);
                    setResult.Player2Games = int.Parse(set.Split('-')[1]);

                    if (match.SetResults != null && match.SetResults.Count > i)
                    {
                        var existingSetResult = match.SetResults[i];
                        existingSetResult.CopyFrom(setResult);
                        setResults.Add(existingSetResult);
                    }
                    else
                    {
                        setResults.Add(setResult);
                    }
                }
                else
                {
                    throw new ArgumentException("Set result has wrong format");
                }
            }
            match.SetResults = setResults;
        }
    }
}