using System.Data.Entity.ModelConfiguration;
using Nop.Plugin.Misc.LLT.Domain;

namespace Nop.Plugin.Misc.LLT.Data
{
    public class PlayerResultMap : EntityTypeConfiguration<PlayerResult>
    {
        public PlayerResultMap()
        {
            ToTable(TablesName.PlayerResultTable);
            HasKey(m => m.Id);

            Property(m => m.Place);
            Property(m => m.Points);
            Property(m => m.DateTime);

            HasRequired(r => r.Tournament);
            HasRequired(r => r.Player);
        }
    }
}
