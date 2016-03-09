using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Nop.Core.Data;
using Nop.Plugin.Misc.LLT.Abstracts;
using Nop.Plugin.Misc.LLT.Domain;
using Nop.Plugin.Misc.LLT.Models;
using Nop.Plugin.Misc.LLT.Models.Match;
using Nop.Plugin.Misc.LLT.Models.Tournament;

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
            return _tournamentMatchRepository.Table.Where(t => t.Tournament.Id == tournamentId).Select(tm => tm.Match).ToList();
        }

        public TournamentModel GetTournament(Match match)
        {
            var result = _tournamentMatchRepository.Table.FirstOrDefault(t => t.Match.Id == match.Id);
            return result != null ? Mapper.Map<Tournament, TournamentModel>(result.Tournament) : null;
        }

        public List<TournamentSingleMatchModel> GetHead2Head(int player1Id, int player2Id)
        {
            var matches =
                _tournamentMatchRepository.Table.Where(tm =>
                    (tm.Match.Player1 != null && tm.Match.Player2 != null)
                    && ((tm.Match.Player1.Id == player1Id && tm.Match.Player2.Id == player2Id) ||
                        (tm.Match.Player1.Id == player2Id && tm.Match.Player2.Id == player1Id))).ToList();

            var result = new List<TournamentSingleMatchModel>();

            result.AddRange(
                matches.Select(match =>
                    new TournamentSingleMatchModel
                    {
                        Match = Mapper.Map<Match, MatchModel>(match.Match),
                        Tournament = Mapper.Map<Tournament, TournamentModel>(match.Tournament)
                    }));

            return result;
        }
    }
}
