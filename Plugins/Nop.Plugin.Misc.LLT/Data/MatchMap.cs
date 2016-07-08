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
