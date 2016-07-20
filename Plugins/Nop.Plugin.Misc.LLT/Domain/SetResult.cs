using System;
using Nop.Core;

namespace Nop.Plugin.Misc.LLT.Domain
{
    public class SetResult : BaseEntity
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

        internal void CopyFrom(SetResult setResult)
        {
            this.Number = setResult.Number;
            this.Player1Games = setResult.Player1Games;
            this.Player2Games = setResult.Player2Games;
            this.Player1TieBreak = setResult.Player1TieBreak;
            this.Player2TieBreak = setResult.Player2TieBreak;
        }

        internal bool IsCompleted()
        {
            var isCompleted = Math.Abs(Player1TieBreak - Player2TieBreak) >= 2 && (Player1TieBreak >= 10 || Player2TieBreak >= 10);
            if (!isCompleted)
            {
                isCompleted = Player1Games + Player2Games == 13 || ((Player1Games >= 6 || Player2Games >= 6) && Math.Abs(Player1Games - Player2Games) >= 2);
            }
            return isCompleted;
        }
    }
}