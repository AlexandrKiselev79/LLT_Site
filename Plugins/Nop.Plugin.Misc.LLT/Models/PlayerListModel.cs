using System.Collections.Generic;
using Nop.Plugin.Misc.LLT.Domain;

namespace Nop.Plugin.Misc.LLT.Models
{
    public class PlayerListModel
    {
        public PlayerListModel()
        {
            Players = new List<Player>();
        }

        public List<Player> Players { get; set; }
    }
}
