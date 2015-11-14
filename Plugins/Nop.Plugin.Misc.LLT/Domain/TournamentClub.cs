using Nop.Core;

namespace Nop.Plugin.Misc.LLT.Domain
{
    public class TournamentClub: BaseEntity
    {
        public virtual Tournament Tournament { get; set; }

        public virtual TennisClub Club { get; set; }
    }
}
