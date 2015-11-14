using System.Collections.Generic;
using Nop.Plugin.Misc.LLT.Domain;
using Nop.Plugin.Misc.LLT.Models;

namespace Nop.Plugin.Misc.LLT.Abstracts
{
    public interface ITournamentMatchService
    {
        List<Match> GetAllMatches(int tournamentId);
        Tournament GetTournament(Match match);
        List<TournamentSingleMatch> GetHead2Head(int player1Id, int player2Id);
    }
}
