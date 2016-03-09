using Nop.Core;

namespace Nop.Plugin.Misc.LLT.Domain
{
    public class TieBreakResult : BaseEntity
    {
        // Тайбрейк очки первого игрока   
        public int Player1TieBreak { get; set; }
        // Тайбрейк очки второго игрока
        public int Player2TieBreak { get; set; }
        // Игрок 1
        public virtual Player Player1 { get; set; }
        // Игрок 2
        public virtual Player Player2 { get; set; }
    }
}
