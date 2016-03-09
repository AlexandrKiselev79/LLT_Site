using System;
using System.Collections.Generic;
using Nop.Plugin.Misc.LLT.Domain;
using Nop.Plugin.Misc.LLT.Enums;

namespace Nop.Plugin.Misc.LLT.Models.Tournament
{
    public class TournamentModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public string StartDateString
        {
            get { return StartDate.ToShortDateString(); }
        }

        public DateTime EndDate { get; set; }

        public string EndDateString
        {
            get { return EndDate.ToShortDateString(); }
        }

        public TournamentType Type { get; set; }

        public List<TournamentClub> Clubs { get; set; }

        public Dictionary<int, int> Rates { get; set; }
    }
}
