using System.Collections.Generic;
using Nop.Plugin.Misc.LLT.Models.Match;
using Nop.Plugin.Misc.LLT.Models.Player;
using Nop.Plugin.Misc.LLT.Models.Tournament;

namespace Nop.Plugin.Misc.LLT.Models
{
    public class Head2HeadModel
    {
        // Список игроков для элемента выбора на странице
        public List<PlayerModel> Players { get; set; }
        // Подробная информация по первому игроку
        public PlayerDetailsModel Player1 { get; set; }
        // Подробная информация по второму игроку
        public PlayerDetailsModel Player2 { get; set; }
        // Сыгранные игроками матчи вызова
        public List<MatchModel> ChallengeMatches { get; set; }
        // Сыгранные игроками турнирные матчи
        public List<TournamentSingleMatchModel> TournamentMatches { get; set; }
    }
}
