using System.Data.Entity.ModelConfiguration;
using Nop.Plugin.Misc.LLT.Domain;

namespace Nop.Plugin.Misc.LLT.Data
{
    public class TournamentClubMap : EntityTypeConfiguration<TournamentClub>
    {
        public TournamentClubMap()
        {
            ToTable(TablesName.TournamentClubsTable);
            HasKey(m => m.Id);

            HasRequired(r => r.Tournament);
            HasRequired(c => c.Club);
        }
    }
}
