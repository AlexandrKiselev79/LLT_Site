using System.Data.Entity.ModelConfiguration;
using Nop.Plugin.Misc.LLT.Domain;

namespace Nop.Plugin.Misc.LLT.Data
{
    public class TournamentMatchMap : EntityTypeConfiguration<TournamentMatch>
    {
        public TournamentMatchMap()
        {
            ToTable(TablesName.TournamentMatchTable);
            HasKey(m => m.Id);

            HasRequired(r => r.Tournament);
            HasMany(m => m.Matches);
        }
    }
}
