using System;
using System.Collections.Generic;
using System.Globalization;
using Nop.Plugin.Misc.LLT.Enums;
using Nop.Plugin.Misc.LLT.Models.TennisClub;

namespace Nop.Plugin.Misc.LLT.Models.Tournament
{
    public class TournamentModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public string StartDateString
        {
            get
            {
                var ci = new CultureInfo("ru-RU");
                return StartDate.ToString("dd MMMM yyyy", ci);
            }
        }

        public DateTime EndDate { get; set; }

        public string EndDateString
        {
            get
            {
                var ci = new CultureInfo("ru-RU");
                return EndDate.ToString("dd MMMM yyyy", ci);
            }
        }

        public TournamentType Type { get; set; }

        public string TypeString
        {
            get { return Type.ToString(); }
        }

        public List<TennisClubModel> Clubs { get; set; }

        public Dictionary<int, int> Rates { get; set; }
    }
}
