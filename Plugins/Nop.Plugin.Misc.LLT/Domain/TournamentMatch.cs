using Nop.Core;

namespace Nop.Plugin.Misc.LLT.Domain
{
    public class TournamentMatch: BaseEntity
    {
        public Tournament Tournament { get; set; }

        public Match Match { get; set; }
    }
}
