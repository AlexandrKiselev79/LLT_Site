using Nop.Plugin.Misc.LLT.Models.Match;

namespace Nop.Plugin.Misc.LLT.Models.Tournament
{
    public class TournamentSingleMatchModel
    {
        public MatchModel Match { get; set; }

        public TournamentModel Tournament { get; set; }
    }
}
