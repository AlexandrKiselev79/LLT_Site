using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nop.Plugin.Misc.LLT.Domain;
using Nop.Plugin.Misc.LLT.Enums;
using Nop.Plugin.Misc.LLT.Extensions;
using Nop.Plugin.Misc.LLT.Models.Player;
using Nop.Plugin.Misc.LLT.Models.TennisClub;

namespace Nop.Plugin.Misc.LLT.Models.Match
{
    public class MatchModel
    {
        public MatchModel()
        {
            this.Stage = TournamentStage.Group;
        }

        public int Id { get; set; }
        public bool IsTournamentMatch { get; set; }

        // Players
        public PlayerModel Player1 { get; set; }
        public PlayerModel Player2 { get; set; }

        public PlayerLevel Player1Level { get; set; }
        public PlayerLevel Player2Level { get; set; }

        public int Player1Ranking { get; set; }
        public int Player2Ranking { get; set; }

        public string CompletionReason { get; set; }
        public int WinnerId { get; set; }

        public TournamentStage Stage { get; set; }

        public string StageString
        {
            get { return Enum.GetName(typeof(TournamentStage), Stage); }
        }

        // Results
        public List<SetResultModel> SetResults { get; set; }

        public string MatchResultString(int playerId)
        {
            var result = new StringBuilder();

            if (SetResults != null && SetResults.Any())
            {
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
            }

            if (WinnerId > 0)
            {
                if (result.Length > 0)
                {
                    result.Append(" ");
                }
                result.AppendFormat("{0}", CompletionReason);
            }
            return result.ToString();
        }

        private string matchResultDisplay;
        public string MatchResultDisplay
        {
            get
            {
                if (!string.IsNullOrEmpty(matchResultDisplay))
                {
                    return matchResultDisplay;
                }

                return MatchResultString(Player1.Id);
            }
            set
            {
                matchResultDisplay = value;
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

        public bool WonInSets(int playerId)
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