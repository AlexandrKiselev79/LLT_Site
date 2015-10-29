using System.Collections.Generic;
using System.Linq;
using Nop.Core.Data;
using Nop.Plugin.Misc.LLT.Abstracts;
using Nop.Plugin.Misc.LLT.Domain;

namespace Nop.Plugin.Misc.LLT.Service
{
    public class ChallengeService : IChallengeService
    {
        private readonly IRepository<Match> _matchRepository;

        public ChallengeService(IRepository<Match> matchRepository)
        {
            _matchRepository = matchRepository;
        }

        public void Add(Match match)
        {
            _matchRepository.Insert(match);
        }

        public void Update(Match match)
        {
            _matchRepository.Update(match);
        }

        public void Delete(Match match)
        {
            match.Deleted = true;
            _matchRepository.Update(match);
        }

        public Match GetById(int matchId)
        {
            return _matchRepository.GetById(matchId);
        }

        public List<Match> GetAll()
        {
            return _matchRepository.Table.ToList();
        }

        public List<Match> GetAllByPlayerId(int playerId)
        {
            return _matchRepository.Table.Where(m => (m.Player1 != null && m.Player1.Id == playerId)
                                                     || (m.Player2 != null && m.Player2.Id == playerId)).ToList();
        }

        public List<Match> GetHead2Head(int player1Id, int player2Id)
        {
            return _matchRepository.Table.Where(m => (m.Player1 != null && m.Player2 != null)
                                                     && ((m.Player1.Id == player1Id && m.Player2.Id == player2Id)
                                                         || (m.Player1.Id == player2Id && m.Player2.Id == player1Id)))
                .ToList();
        }
    }
}
