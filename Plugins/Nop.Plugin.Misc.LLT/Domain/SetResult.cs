using Nop.Core;

namespace Nop.Plugin.Misc.LLT.Domain
{
    public class SetResult: BaseEntity
    {
        // Номер
        public int Number { get; set; }
        // Геймы первого игрока
        public int Player1Games { get; set; }
        // Геймы второго игрока
        public int Player2Games { get; set; }
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
