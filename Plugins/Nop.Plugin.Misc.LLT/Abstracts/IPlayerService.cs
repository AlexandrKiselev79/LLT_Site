using System.Collections.Generic;
using Nop.Plugin.Misc.LLT.Domain;
using Nop.Plugin.Misc.LLT.Enums;
using Nop.Plugin.Misc.LLT.Models.Player;

namespace Nop.Plugin.Misc.LLT.Abstracts
{
    public interface IPlayerService
    {
        void Add(Player player);
        void Update(Player player);
        void Delete(Player player);

        Player GetById(int id);
        PlayerDetailsModel GetDetailsById(int id);
        List<PlayerModel> GetAll();
        List<PlayerModel> GetAll(PlayerLevel level, string fullName = "", string city = "");
    }
}
