using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Nop.Core.Data;
using Nop.Plugin.Misc.LLT.Abstracts;
using Nop.Plugin.Misc.LLT.Domain;
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

        public TournamentModel GetById(int tournamentId)
        {
            var tournament = Mapper.Map<Tournament, TournamentModel>(_tournamentRepository.GetById(tournamentId));
            GetTournamentClubs(tournament);
            return tournament;
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
            GetTournamentClubs(details.GeneralInfo);

            return details;
        }

        public List<TournamentModel> GetAll()
        {
            var tournaments =  _tournamentRepository.Table.Select(Mapper.Map<Tournament, TournamentModel>).ToList();
            foreach (var tournament in tournaments)
            {
                GetTournamentClubs(tournament);
            }
            return tournaments;
        }

        public List<TournamentModel> GetAllInPeriod(DateTime startDate, DateTime endDate)
        {
            var tournaments = _tournamentRepository.Table.Where(t => t.StartDate <= endDate || t.EndDate >= startDate).Select(Mapper.Map<Tournament, TournamentModel>).ToList();
            foreach (var tournament in tournaments)
            {
                GetTournamentClubs(tournament);
            }
            return tournaments;
        }

        private void GetTournamentClubs(TournamentModel tournament)
        {
            tournament.Clubs = _tournamentClubsRepository.Table.Where(tc => tc.Tournament.Id == tournament.Id).ToList();
        }
    }
}
