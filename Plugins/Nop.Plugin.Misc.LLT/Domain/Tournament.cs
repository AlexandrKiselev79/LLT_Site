using System;
using System.Collections.Generic;
using Nop.Core;
using Nop.Plugin.Misc.LLT.Enums;

namespace Nop.Plugin.Misc.LLT.Domain
{
    public class Tournament: BaseEntity
    {
        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public TournamentType Type { get; set; }

        public virtual List<TennisClub> Clubs { get; set; }

        public Dictionary<int, int> Rates { get; set; }

        public string RatesAsJSON
        {
            get { return string.Empty; }
            set { Rates = new Dictionary<int, int>();}
        }

        public virtual List<Match> Matches { get; set; }
    }
}
