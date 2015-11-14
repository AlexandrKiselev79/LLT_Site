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
        private readonly IRepository<TournamentClub> _tournamentClubsRepository;

        public TournamentService(IRepository<Tournament> tournamentRepository, IRepository<TournamentClub> tournamentClubsRepository)
        {
            _tournamentRepository = tournamentRepository;
            _tournamentClubsRepository = tournamentClubsRepository;
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

        public void AddClubs(Tournament tournament, List<TennisClub> clubs)
        {
            var currentLinks = _tournamentClubsRepository.Table.Where(tc => tc.Tournament.Id == tournament.Id);

            foreach (var club in clubs)
            {
                var existClub = currentLinks.FirstOrDefault(c => c.Id == club.Id);
                if (existClub == null)
                {
                    _tournamentClubsRepository.Insert(new TournamentClub
                    {
                        Tournament = tournament,
                        Club = club
                    });
                }
            }
        }

        public Tournament GetById(int tournamentId)
        {
            var tournament = _tournamentRepository.GetById(tournamentId);
            GetTournamentClubs(tournament);
            return tournament;
        }

        public List<Tournament> GetAll()
        {
            var tournaments =  _tournamentRepository.Table.ToList();
            foreach (var tournament in tournaments)
            {
                GetTournamentClubs(tournament);
            }

            return tournaments;
        }

        public List<Tournament> GetAllInPeriod(DateTime startDate, DateTime endDate)
        {
            return _tournamentRepository.Table.Where(t => t.StartDate <= endDate || t.EndDate >= startDate).ToList();
        }

        private void GetTournamentClubs(Tournament tournament)
        {
            tournament.Clubs = _tournamentClubsRepository.Table.Where(tc => tc.Tournament.Id == tournament.Id).ToList();
        }
    }
}
