using Nop.Plugin.Misc.LLT.Enums;

namespace Nop.Plugin.Misc.LLT.Service
{
    public static class EnumService
    {
        public static string GenderTypeString(GenderType type)
        {
            return type.Equals(GenderType.Man) ? "М" : "Ж";
        }

        public static string TournamentTypeString(TournamentType type)
        {
            switch (type)
            {
                case TournamentType.GrandSlam:
                    return "Гранд Слем";
                case TournamentType.Masters:
                    return "Мастерс";
                case TournamentType.Challenger:
                    return "Челленджер";
                case TournamentType.Futures:
                    return "Фьючерс";
                case TournamentType.TieBreakKing:
                    return "Король Тайбрейков";
            }

            return string.Empty;
        }

        public static string CourtTypeString(CourtType type)
        {
            switch (type)
            {
                case CourtType.Hard:
                    return "Хард";
                case CourtType.Grass:
                    return "Трава";
                case CourtType.Clay:
                    return "Грунт";
                case CourtType.Other:
                    return "Другой";
            }

            return string.Empty;
        }
    }
}
