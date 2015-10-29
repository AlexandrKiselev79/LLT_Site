using System.Collections.Generic;
using System.Linq;
using Nop.Core.Data;
using Nop.Plugin.Misc.LLT.Abstracts;
using Nop.Plugin.Misc.LLT.Domain;

namespace Nop.Plugin.Misc.LLT.Service
{
    public class PlayerService : IPlayerService
    {
        private readonly IRepository<Player> _playerRepository;

        public PlayerService(IRepository<Player> playerRepository)
        {
            _playerRepository = playerRepository;
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

        public Player GetById(int id)
        {
            return _playerRepository.GetById(id);
        }

        public List<Player> GetAll()
        {
            return _playerRepository.Table.ToList();
        }
    }
}
