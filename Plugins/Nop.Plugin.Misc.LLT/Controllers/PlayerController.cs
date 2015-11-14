using System.Web.Mvc;
using Nop.Plugin.Misc.LLT.Abstracts;
using Nop.Plugin.Misc.LLT.Models;
using Nop.Web.Framework.Controllers;

namespace Nop.Plugin.Misc.LLT.Controllers
{
    public class PlayerController : BaseController
    {
        private readonly IPlayerService _playerService;
        private readonly IChallengeService _challengeService;
        private readonly ITournamentMatchService _tournamentMatchService;

        public PlayerController(IPlayerService playerService, IChallengeService challengeService, ITournamentMatchService tournamentMatchService)
        {
            _playerService = playerService;
            _challengeService = challengeService;
            _tournamentMatchService = tournamentMatchService;
        }

        public ActionResult List()
        {
            var model = new PlayerListModel
            {
                Players = _playerService.GetAll()
            };

            return View(model);
        }

        public ActionResult Player(int playerId)
        {
            var player = _playerService.GetById(playerId);
            return View(player);
        }

        public ActionResult Head2Head()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Head2Head(int player1Id, int player2Id)
        {
            var model = new Head2HeadModel
            {
                Player1 = _playerService.GetById(player1Id),
                Player2 = _playerService.GetById(player2Id),
                ChallengeMatches = _challengeService.GetHead2Head(player1Id, player2Id),
                TournamentMatches = _tournamentMatchService.GetHead2Head(player1Id, player2Id)
            };

            return View(model);
        }
    }
}
