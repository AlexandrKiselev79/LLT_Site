using System.Data.Entity.ModelConfiguration;
using Nop.Plugin.Misc.LLT.Domain;

namespace Nop.Plugin.Misc.LLT.Data
{
    public class MatchMap : EntityTypeConfiguration<Match>
    {
        public MatchMap()
        {
            ToTable(TablesName.MatchTable);
            HasKey(m => m.Id);

            Property(m => m.IsTournamentMatch);

            HasRequired(r => r.Player1);
            HasRequired(r => r.Player2);

            Property(m => m.Player1Level);
            Property(m => m.Player2Level);

            Property(m => m.Player1Ranking);
            Property(m => m.Player2Ranking);

            Property(m => m.CompletionReason);
            Property(m => m.WinnerId);

            HasMany(m => m.SetResults);
            HasOptional(o => o.TieBreakResult);

            HasRequired(r => r.Club);
            Property(m => m.CourtNumber);
            Property(m => m.StartDateTime);
            Property(m => m.Stage);

            Property(m => m.Deleted);
        }
    }
}
