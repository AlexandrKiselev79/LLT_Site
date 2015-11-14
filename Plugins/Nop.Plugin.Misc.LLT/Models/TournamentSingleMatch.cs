using Nop.Plugin.Misc.LLT.Domain;

namespace Nop.Plugin.Misc.LLT.Models
{
    public class TournamentSingleMatch
    {
        public Match Match { get; set; }

        public Tournament Tournament { get; set; }
    }
}
