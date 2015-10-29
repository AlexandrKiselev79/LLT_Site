using System.Data.Entity.ModelConfiguration;
using Nop.Plugin.Misc.LLT.Domain;

namespace Nop.Plugin.Misc.LLT.Data
{
    public class TournamentMap : EntityTypeConfiguration<Tournament>
    {
        public TournamentMap()
        {
            ToTable(TablesName.TournamentTable);
            HasKey(m => m.Id);

            Property(m => m.Name);
            Property(m => m.StartDate);
            Property(m => m.EndDate);
            Property(m => m.Type);
            Property(m => m.RatesAsJSON).HasColumnName("Rates");
            Property(m => m.Deleted);

            HasMany(c => c.Clubs);
            HasMany(c => c.Matches);
        }
    }
}
