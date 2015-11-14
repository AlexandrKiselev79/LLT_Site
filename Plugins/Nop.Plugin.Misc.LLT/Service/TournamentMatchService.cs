using System.Collections.Generic;
using System.Linq;
using Nop.Core.Data;
using Nop.Plugin.Misc.LLT.Abstracts;
using Nop.Plugin.Misc.LLT.Domain;
using Nop.Plugin.Misc.LLT.Models;

namespace Nop.Plugin.Misc.LLT.Service
{
    public class TournamentMatchService : ITournamentMatchService
    {
        private readonly IRepository<TournamentMatch> _tournamentMatchRepository;

        public TournamentMatchService(IRepository<TournamentMatch> tournamentMatchRepository)
        {
            _tournamentMatchRepository = tournamentMatchRepository;
        }

        public List<Match> GetAllMatches(int tournamentId)
        {
            return _tournamentMatchRepository.Table.Where(t => t.Tournament.Id == tournamentId).SelectMany(tm => tm.Matches).ToList();
        }

        public Tournament GetTournament(Match match)
        {
            var result = _tournamentMatchRepository.Table.FirstOrDefault(t => t.Matches.Any(m => m.Id == match.Id));
            return result != null ? result.Tournament : null;
        }

        public List<TournamentSingleMatch> GetHead2Head(int player1Id, int player2Id)
        {
            var matches =
                _tournamentMatchRepository.Table.Where(
                    tm => tm.Matches.Any(m => (m.Player1 != null && m.Player2 != null)
                                              &&
                                              ((m.Player1.Id == player1Id && m.Player2.Id == player2Id) ||
                                               (m.Player1.Id == player2Id && m.Player2.Id == player1Id)))).ToList();

            var result = new List<TournamentSingleMatch>();
            foreach (var tournamentMatch in matches)
            {
                result.AddRange(tournamentMatch.Matches.Select(match => new TournamentSingleMatch {Match = match, Tournament = tournamentMatch.Tournament}));
            }

            return result;
        }
    }
}
