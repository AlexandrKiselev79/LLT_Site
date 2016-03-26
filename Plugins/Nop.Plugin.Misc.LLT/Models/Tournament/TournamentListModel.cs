using System.Collections.Generic;
using Nop.Plugin.Misc.LLT.Enums;

namespace Nop.Plugin.Misc.LLT.Models.Tournament
{
    public class TournamentListModel
    {
        public TournamentListModel()
        {
            Tournaments = new List<TournamentModel>();
        }

        public List<TournamentModel> Tournaments { get; set; }

        public string SearchName { get; set; }

        public TournamentType SearchType { get; set; }
    }
}
