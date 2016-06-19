using System.Collections.Generic;
using Nop.Plugin.Misc.LLT.Models.Match;
using Nop.Plugin.Misc.LLT.Models.Player;

namespace Nop.Plugin.Misc.LLT.Models.Tournament
{
    public class TournamentDetailsModel
    {
        public TournamentDetailsModel()
        {
            GeneralInfo = new TournamentModel();
            Players = new List<PlayerModel>();
            PlannedMatches = new List<MatchModel>();
            PlayedMatches = new List<MatchModel>();
        }

        // Информация о турнире
        public TournamentModel GeneralInfo { get; set; }
        // Список игроков
        public List<PlayerModel> Players { get; set; }
        // Список планируемых матчей
        public List<MatchModel> PlannedMatches { get; set; }
        // Список сыгранных матчей
        public List<MatchModel> PlayedMatches { get; set; }
    }
}
