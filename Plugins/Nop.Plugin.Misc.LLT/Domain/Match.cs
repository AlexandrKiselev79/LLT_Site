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
        }

        public bool IsTournamentMatch { get; set; }

        // Players
        public virtual Player Player1 { get; set; }

        public virtual Player Player2 { get; set; }

        // Results
        public virtual List<SetResult> SetResults { get; set; }

        public virtual TieBreakResult TieBreakResult { get; set; }

        // Schedule

        public virtual TennisClub Club { get; set; }

        public int CourtNumber { get; set; }

        public DateTime StartDateTime { get; set; }
    }
}
