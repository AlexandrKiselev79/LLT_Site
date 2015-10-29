using System;
using System.Collections.Generic;
using System.Linq;
using Nop.Core.Data;
using Nop.Plugin.Misc.LLT.Abstracts;
using Nop.Plugin.Misc.LLT.Domain;

namespace Nop.Plugin.Misc.LLT.Service
{
    public class TournamentMatchService : ITournamentMatchService
    {
        private readonly IRepository<TournamentMatch> _tournamentRepository;

        public TournamentMatchService(IRepository<TournamentMatch> tournamentRepository)
        {
            _tournamentRepository = tournamentRepository;
        }

        public List<Match> GetAllMatches(int tournamentId)
        {
            return _tournamentRepository.Table.Where(t => t.Tournament.Id == tournamentId).Select(tm => tm.Matches);
        }

        public Tournament GetTournament(Match match)
        {
            throw new NotImplementedException();
        }
    }
}
