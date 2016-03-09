using System;
using System.Collections.Generic;
using Nop.Core;

namespace Nop.Plugin.Misc.LLT.Domain
{
    public class Match : BaseEntity
    {
        public Match()
        {
            StartDateTime = DateTime.UtcNow;
            IsTournamentMatch = true;
            Deleted = false;
        }
        // Матч турнира или вызова
        public bool IsTournamentMatch { get; set; }
        // Игрок 1
        public virtual Player Player1 { get; set; }
        // Игрок 2
        public virtual Player Player2 { get; set; }
        // Результаты в сетах
        public virtual List<SetResult> SetResults { get; set; }
        // Результаты решающего тайбрека
        public virtual TieBreakResult TieBreakResult { get; set; }
        // Место игры
        public virtual TennisClub Club { get; set; }
        // Номер корта
        public int CourtNumber { get; set; }
        // Дата начала игры
        public DateTime StartDateTime { get; set; }

        public bool Deleted { get; set; }
    }
}
