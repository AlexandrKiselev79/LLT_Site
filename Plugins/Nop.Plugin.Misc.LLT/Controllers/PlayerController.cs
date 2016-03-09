using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Nop.Plugin.Misc.LLT.Abstracts;
using Nop.Plugin.Misc.LLT.Domain;
using Nop.Plugin.Misc.LLT.Models;
using Nop.Plugin.Misc.LLT.Models.Match;
using Nop.Plugin.Misc.LLT.Models.Player;
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
            var player = _playerService.GetDetailsById(playerId);
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
                Player1 = _playerService.GetDetailsById(player1Id),
                Player2 = _playerService.GetDetailsById(player2Id),
                ChallengeMatches = _challengeService.GetHead2Head(player1Id, player2Id).Select(Mapper.Map<Match, MatchModel>).ToList(),
                TournamentMatches = _tournamentMatchService.GetHead2Head(player1Id, player2Id)
            };

            return View(model);
        }
    }
}
