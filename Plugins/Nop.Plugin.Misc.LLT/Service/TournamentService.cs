using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Nop.Core.Data;
using Nop.Plugin.Misc.LLT.Abstracts;
using Nop.Plugin.Misc.LLT.Domain;
using Nop.Plugin.Misc.LLT.Enums;
using Nop.Plugin.Misc.LLT.Models.Match;
using Nop.Plugin.Misc.LLT.Models.Tournament;

namespace Nop.Plugin.Misc.LLT.Service
{
    public class TournamentService : ITournamentService
    {
        private readonly IRepository<Tournament> _tournamentRepository;
        private readonly IRepository<TournamentClub> _tournamentClubsRepository;
        private readonly IRepository<TournamentMatch> _tournamentMatchRepository;

        public TournamentService(IRepository<Tournament> tournamentRepository, IRepository<TournamentClub> tournamentClubsRepository,
            IRepository<Match> matchRepository, IRepository<TournamentMatch> tournamentMatchRepository)
        {
            _tournamentRepository = tournamentRepository;
            _tournamentClubsRepository = tournamentClubsRepository;
            _tournamentMatchRepository = tournamentMatchRepository;
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
            return _tournamentRepository.GetById(tournamentId);
        }

        public TournamentDetailsModel GetDetailsById(int tournamentId)
        {
            var matches = _tournamentMatchRepository.Table.Where(m => m.Tournament.Id == tournamentId).Select(tm => tm.Match).ToList();
            var details = new TournamentDetailsModel
            {
                GeneralInfo = Mapper.Map<Tournament, TournamentModel>(_tournamentRepository.GetById(tournamentId)),
                PlayedMatches = matches.Where(m => m.SetResults != null && m.SetResults.Any()).Select(Mapper.Map<Match, MatchModel>).ToList(),
                PlannedMatches = matches.Where(m => m.SetResults == null || !m.SetResults.Any()).Select(Mapper.Map<Match, MatchModel>).ToList()
            };
            //GetTournamentClubs(details.GeneralInfo);

            return details;
        }

        public List<Tournament> GetAll()
        {
            return  _tournamentRepository.Table.ToList();
        }

        public List<Tournament> GetAllInPeriod(DateTime startDate, DateTime endDate)
        {
            return _tournamentRepository.Table.Where(t => t.StartDate <= endDate || t.EndDate >= startDate).ToList();
        }

        public List<Tournament> GetAll(TournamentType searchType, string searchName)
        {
            var tournaments = _tournamentRepository.Table;

            if (!searchType.Equals(TournamentType.All))
            {
                tournaments = tournaments.Where(t => t.Type == searchType);
            }

            if (!string.IsNullOrEmpty(searchName))
            {
                tournaments = tournaments.Where(t => t.Name.ToLower().Contains(searchName.Trim().ToLower()));
            }

            return tournaments.ToList();
        }
    }
}
