using Nop.Core;

namespace Nop.Plugin.Misc.LLT.Domain
{
    public class TieBreakResult : BaseEntity
    {
        public int Player1TieBreak { get; set; }

        public int Player2TieBreak { get; set; }

        public virtual Player Player1 { get; set; }

        public virtual Player Player2 { get; set; }
    }
}
