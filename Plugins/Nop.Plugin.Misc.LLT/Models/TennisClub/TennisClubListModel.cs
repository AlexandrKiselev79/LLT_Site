using System.Collections.Generic;

namespace Nop.Plugin.Misc.LLT.Models.TennisClub
{
    public class TennisClubListModel
    {
        public TennisClubListModel()
        {
            Clubs = new List<TennisClubModel>();
        }

        public List<TennisClubModel> Clubs { get; set; }
    }
}
