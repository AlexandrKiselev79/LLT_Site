using Nop.Core;

namespace Nop.Plugin.Misc.LLT.Domain
{
    public class SetResult: BaseEntity
    {
        public int Number { get; set; }

        public int Player1Games { get; set; }

        public int Player2Games { get; set; }

        public int Player1TieBreak { get; set; }

        public int Player2TieBreak { get; set; }

        public virtual Player Player1 { get; set; }

        public virtual Player Player2 { get; set; }
    }
}
