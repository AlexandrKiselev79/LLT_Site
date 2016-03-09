using System.Collections.Generic;
using Nop.Plugin.Misc.LLT.Models.Match;
using Nop.Plugin.Misc.LLT.Models.Tournament;

namespace Nop.Plugin.Misc.LLT.Models.Player
{
    public class PlayerDetailsModel
    {
        public PlayerDetailsModel()
        {
            GeneralInfo = new PlayerModel();
            PlannedMatches = new List<MatchModel>();
            PlayedMatches = new List<MatchModel>();
        }
        // Информация о игроке
        public PlayerModel GeneralInfo { get; set; }
        // Список планируемых матчей
        public List<MatchModel> PlannedMatches { get; set; }
        // Список сыгранных матчей
        public List<MatchModel> PlayedMatches { get; set; }
        // Список турниров
        public List<TournamentModel> Tournaments { get; set; }
        // Текущий рейтинг
        public int GeneralRating { get; set; }
        // Рейтинг в чемпионской гонке
        public int ChampionshipRating { get; set; }
        // Рейтинг в королях тайбрейка
        public int TieBreakKingRating { get; set; }
        // Текущая позиция
        public int RatingNumber { get; set; }
        // Наивысшая позиция за все время
        public int HighestRatingNumber { get; set; }
    }
}
