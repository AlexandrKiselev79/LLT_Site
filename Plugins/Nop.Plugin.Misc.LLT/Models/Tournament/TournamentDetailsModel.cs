using System.Collections.Generic;
using Nop.Plugin.Misc.LLT.Models.Match;

namespace Nop.Plugin.Misc.LLT.Models.Tournament
{
    public class TournamentDetailsModel
    {
        // Информация о турнире
        public TournamentModel GeneralInfo { get; set; }
        // Список планируемых матчей
        public List<MatchModel> PlannedMatches { get; set; }
        // Список сыгранных матчей
        public List<MatchModel> PlayedMatches { get; set; }
    }
}
