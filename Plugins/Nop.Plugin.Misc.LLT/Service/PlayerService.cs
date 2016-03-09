using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Nop.Core.Data;
using Nop.Plugin.Misc.LLT.Abstracts;
using Nop.Plugin.Misc.LLT.Domain;
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
            _playerRepository.Update(player);
        }

        public void Delete(Player player)
        {
            player.Deleted = true;
            _playerRepository.Update(player);
        }

        public PlayerModel GetById(int id)
        {
            return Mapper.Map<Player, PlayerModel>(_playerRepository.GetById(id));
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
            var players = _playerRepository.Table.ToList();
            return players.Select(Mapper.Map<Player, PlayerModel>).ToList();
        }
    }
}
