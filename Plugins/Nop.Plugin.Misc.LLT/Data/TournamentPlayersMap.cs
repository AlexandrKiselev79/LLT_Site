using System.Data.Entity.ModelConfiguration;
using Nop.Plugin.Misc.LLT.Domain;

namespace Nop.Plugin.Misc.LLT.Data
{
    public class TournamentPlayersMap : EntityTypeConfiguration<TournamentPlayer>
    {
        public TournamentPlayersMap()
        {
            ToTable(TablesName.TournamentPlayerTable);
            HasKey(tp => tp.Id);

            HasRequired(r => r.Tournament);
            HasRequired(p => p.Player);
        }
    }
}