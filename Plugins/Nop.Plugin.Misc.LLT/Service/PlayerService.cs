using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Nop.Core.Data;
using Nop.Plugin.Misc.LLT.Abstracts;
using Nop.Plugin.Misc.LLT.Domain;
using Nop.Plugin.Misc.LLT.Enums;
using Nop.Plugin.Misc.LLT.Models.Match;
using Nop.Plugin.Misc.LLT.Models.Player;

namespace Nop.Plugin.Misc.LLT.Service
{
    public class PlayerService : IPlayerService
    {
        private readonly IRepository<Player> _playerRepository;
        private readonly IRepository<Match> _matchRepository;

        public PlayerService(IRepository<Player> playerRepository, IRepository<Match> matchRepository)
        {
            _playerRepository = playerRepository;
            _matchRepository = matchRepository;
        }

        public void Add(Player player)
        {
            _playerRepository.Insert(player);
        }

        public void Update(Player player)
        {
            var existedPlayer = _playerRepository.GetById(player.Id);
            existedPlayer.CopyFrom(player);
            _playerRepository.Update(existedPlayer);
        }

        public void Delete(Player player)
        {
            player.Deleted = true;
            _playerRepository.Update(player);
        }

        public Player GetById(int id)
        {
            return _playerRepository.Table.FirstOrDefault(p => p.Id == id);
        }

        public PlayerDetailsModel GetDetailsById(int id)
        {
            var matches = _matchRepository.Table.Where(m => m.Player1.Id == id || m.Player2.Id == id).ToList();
            var model = new PlayerDetailsModel
            {
                GeneralInfo = Mapper.Map<Player, PlayerModel>(_playerRepository.GetById(id)),
                PlayedMatches = matches.Where(m => m.SetResults != null && m.SetResults.Any()).Select(Mapper.Map<Match, MatchModel>).ToList(),
                PlannedMatches = matches.Where(m => m.SetResults == null || !m.SetResults.Any()).Select(Mapper.Map<Match, MatchModel>).ToList()
            };
            return model;
        }

        public List<PlayerModel> GetAll()
        {
            var players = _playerRepository.Table.Where(p => !p.Deleted).ToList();
            return players.Select(Mapper.Map<Player, PlayerModel>).ToList();
        }

        public List<PlayerModel> GetAll(PlayerLevel level, string fullName = "", string city = "")
        {
            var players = _playerRepository.Table.Where(p => !p.Deleted).ToList();

            var models = players.Select(Mapper.Map<Player, PlayerModel>).ToList();

            if (level != PlayerLevel.All)
            {
                models = models.Where(p => p.Level == level).ToList();
            }

            if (!string.IsNullOrEmpty(fullName))
            {
                models = models.Where(p => p.FullName.Trim().ToLower().Contains(fullName.Trim().ToLower())).ToList();
            }

            if (!string.IsNullOrEmpty(city))
            {
                models = models.Where(p => p.City.Trim().ToLower().Contains(city.Trim().ToLower())).ToList();
            }

            return models;
        }
    }
}
