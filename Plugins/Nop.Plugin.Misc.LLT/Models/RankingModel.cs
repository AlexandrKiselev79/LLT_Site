using System;

namespace Nop.Plugin.Misc.LLT.Models
{
    public class RankingModel
    {
        public int Current { get; set; }
        public DateTime CurrentRankingDate { get; set; }
        public int? Best { get; set; }
        public DateTime? BestRankingDate { get; set; }

        public string CurrentRankingString
        {
            get
            {
                var currentRankingString = "";
                if (this.Current > 0)
                {
                    currentRankingString = this.Current.ToString();
                }
                else
                {
                    currentRankingString = "N/A";
                }

                return currentRankingString;
            }
        }

        public string BestRankingString
        {
            get
            {
                var bestRankingString = "";
                if (this.Best.HasValue && this.BestRankingDate.HasValue)
                {
                    bestRankingString = string.Format("{0} ({1})", this.Best.Value, this.BestRankingDate.Value.ToString("dd.MM.yyyy"));
                }
                else
                {
                    bestRankingString = "N/A";
                }
                
                return bestRankingString;
            }
        }
    }
}