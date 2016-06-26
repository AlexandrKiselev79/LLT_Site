﻿using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Nop.Core.Data;
using Nop.Plugin.Misc.LLT.Abstracts;
using Nop.Plugin.Misc.LLT.Domain;
using Nop.Plugin.Misc.LLT.Enums;
using Nop.Plugin.Misc.LLT.Models.Match;
using Nop.Plugin.Misc.LLT.Models.Player;
using Nop.Plugin.Misc.LLT.Models.Tournament;

namespace Nop.Plugin.Misc.LLT.Service
{
    public class TournamentService : ITournamentService
    {
        private readonly IRepository<Tournament> _tournamentRepository;
        private readonly IRepository<TournamentClub> _tournamentClubsRepository;
        private readonly IRepository<TournamentMatch> _tournamentMatchRepository;
        private readonly IRepository<TournamentPlayer> _tournamentPlayerRepository;

        public TournamentService(IRepository<Tournament> tournamentRepository, IRepository<TournamentClub> tournamentClubsRepository,
            IRepository<Match> matchRepository, IRepository<TournamentMatch> tournamentMatchRepository, IRepository<TournamentPlayer> tournamentPlayerRepository)
        {
            _tournamentRepository = tournamentRepository;
            _tournamentClubsRepository = tournamentClubsRepository;
            _tournamentMatchRepository = tournamentMatchRepository;
            _tournamentPlayerRepository = tournamentPlayerRepository;
        }

        public void Create(Tournament tournament)
        {
            _tournamentRepository.Insert(tournament);
        }

        public void Update(Tournament tournament)
        {
            _tournamentRepository.Update(tournament);
        }

        public void AddPlayer(Tournament tournament, Player player)
        {
            var tournamentPlayer = new TournamentPlayer(tournament, player);
            _tournamentPlayerRepository.Insert(tournamentPlayer);
        }

        public void UpdatePlayer(Tournament tournament, Player player)
        {
            var tournamentPlayer = _tournamentPlayerRepository.Table.Where(tp => tp.Tournament.Id == tournament.Id && tp.Player.Id == player.Id).ToList();
            _tournamentPlayerRepository.Update(tournamentPlayer);
        }

        public void RemovePlayer(Tournament tournament, Player player) {
            var tournamentPlayer = _tournamentPlayerRepository.Table.Where(tp => tp.Tournament.Id == tournament.Id && tp.Player.Id == player.Id).ToList();
            _tournamentPlayerRepository.Delete(tournamentPlayer);
        }

        public void AddMatch(Tournament tournament, Match match)
        {
            var tournamentMatch = new TournamentMatch(tournament, match);
            _tournamentMatchRepository.Insert(tournamentMatch);
        }

        public void UpdateMatch(Tournament tournament, Match match)
        {
            var tournamentMatch = _tournamentMatchRepository.Table.Where(tp => tp.Tournament.Id == tournament.Id && tp.Match.Id == match.Id).ToList();
            _tournamentMatchRepository.Update(tournamentMatch);
        }

        public void RemoveMatch(Tournament tournament, Match match)
        {
            var tournamentMatch = _tournamentMatchRepository.Table.Where(tp => tp.Tournament.Id == tournament.Id && tp.Match.Id == match.Id).ToList();
            _tournamentMatchRepository.Delete(tournamentMatch);
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

            var players = new List<PlayerModel>();
            var tournamentPlayers = _tournamentPlayerRepository.Table.Where(t => t.Tournament.Id == tournamentId).Select(tp => tp.Player).ToList();
            tournamentPlayers.ForEach((p) => {
                players.Add(Mapper.Map<Player, PlayerModel>(p));
            });

            var details = new TournamentDetailsModel
            {
                GeneralInfo = Mapper.Map<Tournament, TournamentModel>(_tournamentRepository.GetById(tournamentId)),
                PlayedMatches = matches.Where(m => m.SetResults != null && m.SetResults.Any()).Select(Mapper.Map<Match, MatchModel>).ToList(),
                PlannedMatches = matches.Where(m => m.SetResults == null || !m.SetResults.Any()).Select(Mapper.Map<Match, MatchModel>).ToList(),
                Players = players
            };

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
