using System.Data.Entity.ModelConfiguration;
using Nop.Plugin.Misc.LLT.Domain;

namespace Nop.Plugin.Misc.LLT.Data
{
    public class TieBreakResultMap: EntityTypeConfiguration<TieBreakResult>
    {
        public TieBreakResultMap()
        {
            ToTable(TablesName.TieBreakResultTable);
            HasKey(m => m.Id);

            Property(m => m.Player1TieBreak);
            Property(m => m.Player1TieBreak);

            HasRequired(r => r.Player1);
            HasRequired(r => r.Player2);
        }
    }
}
