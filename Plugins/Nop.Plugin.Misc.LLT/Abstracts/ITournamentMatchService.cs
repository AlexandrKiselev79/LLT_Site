using System.Collections.Generic;
using Nop.Plugin.Misc.LLT.Domain;
using Nop.Plugin.Misc.LLT.Models;
using Nop.Plugin.Misc.LLT.Models.Tournament;

namespace Nop.Plugin.Misc.LLT.Abstracts
{
    public interface ITournamentMatchService
    {
        List<Match> GetAllMatches(int tournamentId);
        TournamentModel GetTournament(Match match);
        List<TournamentSingleMatchModel> GetHead2Head(int player1Id, int player2Id);
    }
}
