using System.Data.Entity.ModelConfiguration;
using Nop.Plugin.Misc.LLT.Domain;

namespace Nop.Plugin.Misc.LLT.Data
{
    public class TennisClubMap : EntityTypeConfiguration<TennisClub>
    {
        public TennisClubMap()
        {
            ToTable(TablesName.TennisClubTable);
            HasKey(m => m.Id);

            Property(m => m.Name);
            Property(m => m.Email);
            Property(m => m.Description);
            Property(m => m.CourtsAsJSON).HasColumnName("Courts");

            HasRequired(r => r.Address);
        }
    }
}
