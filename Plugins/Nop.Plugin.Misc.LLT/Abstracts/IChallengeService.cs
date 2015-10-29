using System.Collections.Generic;
using Nop.Plugin.Misc.LLT.Domain;

namespace Nop.Plugin.Misc.LLT.Abstracts
{
    public interface IChallengeService
    {
        void Add(Match match);
        void Update(Match match);
        void Delete(Match match);

        Match GetById(int matchId);
        List<Match> GetAll();
        List<Match> GetAllByPlayerId(int playerId);
        List<Match> GetHead2Head(int player1Id, int player2Id);
    }
}
