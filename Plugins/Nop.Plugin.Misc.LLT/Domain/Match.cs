using System;
using System.Collections.Generic;
using Nop.Core;
using Nop.Plugin.Misc.LLT.Enums;

namespace Nop.Plugin.Misc.LLT.Domain
{
    public class Match : BaseEntity
    {
        public Match()
        {
            StartDateTime = DateTime.UtcNow;
            IsTournamentMatch = true;

            Player1Level = PlayerLevel.All;
            Player2Level = PlayerLevel.All;

            Deleted = false;
        }
        // Матч турнира или вызова
        public bool IsTournamentMatch { get; set; }
        // Игрок 1
        public virtual Player Player1 { get; set; }
        // Игрок 2
        public virtual Player Player2 { get; set; }

        public PlayerLevel Player1Level { get; set; }
        public PlayerLevel Player2Level { get; set; }

        public int Player1Ranking { get; set; }
        public int Player2Ranking { get; set; }
        
        public string CompletionReason { get; set; }
        public int WinnerId { get; set; }

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
        
        public TournamentStage Stage { get; set; }

        public bool Deleted { get; set; }

        internal void CopyFrom(Match match)
        {
            IsTournamentMatch = match.IsTournamentMatch;
            Player1 = match.Player1;
            Player2 = match.Player2;
            SetResults = match.SetResults;
            TieBreakResult = match.TieBreakResult;
            Club = match.Club;
            CourtNumber = match.CourtNumber;
            StartDateTime = match.StartDateTime;
            Stage = match.Stage;
            Deleted = match.Deleted;
        }
    }
}
