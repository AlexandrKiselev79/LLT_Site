using System.Collections.Generic;
using Nop.Plugin.Misc.LLT.Domain;

namespace Nop.Plugin.Misc.LLT.Abstracts
{
    public interface ITournamentMatchService
    {
        List<Match> GetAllMatches(int tournamentId);
        Tournament GetTournament(Match match);
    }
}
