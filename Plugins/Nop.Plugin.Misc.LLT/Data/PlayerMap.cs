using System.Data.Entity.ModelConfiguration;
using Nop.Plugin.Misc.LLT.Domain;

namespace Nop.Plugin.Misc.LLT.Data
{
    public class PlayerMap : EntityTypeConfiguration<Player>
    {
        public PlayerMap()
        {
            ToTable("Player");
            HasKey(m => m.Id);

            Property(m => m.FirstName);
            Property(m => m.LastName);
            Property(m => m.Rating);
        }
    }
}
