using System.Collections.Generic;
using Nop.Plugin.Misc.LLT.Enums;

namespace Nop.Plugin.Misc.LLT.Models.Player
{
    public class PlayerListModel
    {
        public PlayerListModel()
        {
            Players = new List<PlayerModel>();
        }

        public List<PlayerModel> Players { get; set; }

        public string SearchTotalName { get; set; }

        public PlayerLevel SearchLevel { get; set; }
    }
}
