using System;
using System.Collections.Generic;
using System.Text;
using Nop.Plugin.Misc.LLT.Domain;
using Nop.Plugin.Misc.LLT.Enums;
using Nop.Plugin.Misc.LLT.Models.Player;
using Nop.Plugin.Misc.LLT.Models.TennisClub;

namespace Nop.Plugin.Misc.LLT.Models.Match
{
    public class MatchModel
    {
        public int Id { get; set; }
        public bool IsTournamentMatch { get; set; }

        // Players
        public PlayerModel Player1 { get; set; }
        public PlayerModel Player2 { get; set; }

        public TournamentStage Stage { get; set; }

        public string StageString
        {
            get { return Enum.GetName(typeof(TournamentStage), Stage); }
        }

        // Results
        public List<SetResultModel> SetResults { get; set; }

        public string MatchResultString(int playerId)
        {
            if (SetResults == null) return string.Empty;
            var result = new StringBuilder();
            foreach (var setResult in SetResults)
            {
                result.Append(setResult.Player1.Id == playerId
                    ? string.Format("{0}-{1} ", setResult.Player1Games, setResult.Player2Games)
                    : string.Format("{0}-{1} ", setResult.Player2Games, setResult.Player1Games));
            }

            if (TieBreakResult != null)
                result.Append(TieBreakResult.Player1.Id == playerId
                    ? string.Format("{0}-{1} ", TieBreakResult.Player1TieBreak, TieBreakResult.Player2TieBreak)
                    : string.Format("{0}-{1} ", TieBreakResult.Player2TieBreak, TieBreakResult.Player1TieBreak));

            return result.ToString();
        }

        public string MatchResultDisplay
        {
            get
            {
                return MatchResultString(Player1.Id);
            }
        }

        public TieBreakResult TieBreakResult { get; set; }

        // Schedule
        public TennisClubModel Club { get; set; }
        public int CourtNumber { get; set; }
        public DateTime StartDateTime { get; set; }

        public bool IsWonBy(int playerId)
        {
            if (TieBreakResult != null
                && TieBreakResult.Player1.Id == playerId
                && TieBreakResult.Player1TieBreak > TieBreakResult.Player2TieBreak)
                return true;

            if (TieBreakResult != null
                && TieBreakResult.Player2.Id == playerId
                && TieBreakResult.Player2TieBreak > TieBreakResult.Player1TieBreak)
                return true;

            return false;
        }

        private bool WonInSets(int playerId)
        {
            if (SetResults != null)
            {
                var wonSetCount = 0;
                var lostSetCount = 0;

                foreach (var setResult in SetResults)
                {
                    if (setResult.WonBy(playerId))
                        wonSetCount++;
                    else
                        lostSetCount++;
                }

                if (wonSetCount > lostSetCount)
                    return true;
            }

            return false;
        }
    }
}