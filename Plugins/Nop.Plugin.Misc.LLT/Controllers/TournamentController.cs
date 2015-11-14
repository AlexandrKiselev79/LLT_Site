using System.Web.Mvc;
using Nop.Plugin.Misc.LLT.Abstracts;
using Nop.Plugin.Misc.LLT.Models;
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
                Tournaments = _tournamentService.GetAll()
            };
            //return View("~/Plugins/Misc.LLT/Views/Tournaments.cshtml", model);
            return View(model);
        }

        public ActionResult Item(int tournamentId)
        {
            return View();
        }
    }
}
