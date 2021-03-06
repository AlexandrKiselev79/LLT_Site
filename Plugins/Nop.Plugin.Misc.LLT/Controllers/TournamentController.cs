﻿using System.Linq;
using System.Web.Mvc;
using Nop.Plugin.Misc.LLT.Abstracts;
using Nop.Plugin.Misc.LLT.Extensions;
using Nop.Plugin.Misc.LLT.Models.Tournament;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Security;

namespace Nop.Plugin.Misc.LLT.Controllers
{
    [NopHttpsRequirement(SslRequirement.NoMatter)]
    public class TournamentController : BasePluginController
    {
        private readonly IPlayerService _playerService;
        private readonly IChallengeService _challengeService;
        private readonly ITournamentService _tournamentService;

        public TournamentController(IPlayerService playerService, IChallengeService challengeService, ITournamentService tournamentService)
        {
            _playerService = playerService;
            _challengeService = challengeService;
            _tournamentService = tournamentService;
        }

        public ActionResult List()
        {
            var model = new TournamentListModel
            {
                Tournaments = _tournamentService.GetAll().Select(x => x.ToModel()).ToList()
            };
            return View(model);
        }

        public ActionResult Tournament(int tournamentId)
        {
            var model = _tournamentService.GetDetailsById(tournamentId);
            return View(model);
        }
    }
}
