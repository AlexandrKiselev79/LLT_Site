using System;
using System.Collections.Generic;
using System.Linq;
using Nop.Core.Data;
using Nop.Plugin.Misc.LLT.Abstracts;
using Nop.Plugin.Misc.LLT.Domain;

namespace Nop.Plugin.Misc.LLT.Service
{
    public class TournamentService : ITournamentService
    {
        private readonly IRepository<Tournament> _tournamentRepository;

        public TournamentService(IRepository<Tournament> tournamentRepository)
        {
            _tournamentRepository = tournamentRepository;
        }

        public void Create(Tournament tournament)
        {
            _tournamentRepository.Insert(tournament);
        }

        public void Update(Tournament tournament)
        {
            _tournamentRepository.Update(tournament);
        }

        public void Delete(Tournament tournament)
        {
            tournament.Deleted = true;
            _tournamentRepository.Update(tournament);
        }

        public Tournament GetById(int tournamentId)
        {
            return _tournamentRepository.GetById(tournamentId);
        }

        public List<Tournament> GetAll()
        {
            return _tournamentRepository.Table.ToList();
        }

        public List<Tournament> GetAllInPeriod(DateTime startDate, DateTime endDate)
        {
            return _tournamentRepository.Table.Where(t => t.StartDate <= endDate || t.EndDate >= startDate).ToList();
        }
    }
}
