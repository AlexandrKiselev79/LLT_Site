using System.ComponentModel;

namespace Nop.Plugin.Misc.LLT.Enums
{
    public enum TournamentType
    {
        GrandSlam = 0,
        [Description("Мастер")]
        Master = 1,
        [Description("Челленджер")]
        Challenger = 2,
        [Description("Фьючерс")]
        Futures = 3,
        [Description("Сателлит")]
        Satellite = 4,
        Other = 5
    }
}
