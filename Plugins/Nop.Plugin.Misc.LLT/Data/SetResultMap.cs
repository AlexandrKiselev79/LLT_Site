using System.Data.Entity.ModelConfiguration;
using Nop.Plugin.Misc.LLT.Domain;

namespace Nop.Plugin.Misc.LLT.Data
{
    public class SetResultMap : EntityTypeConfiguration<SetResult>
    {
        public SetResultMap()
        {
            ToTable(TablesName.SetResultTable);
            HasKey(m => m.Id);

            Property(m => m.Number);
            Property(m => m.Player1Games);
            Property(m => m.Player2Games);
            Property(m => m.Player1TieBreak);
            Property(m => m.Player2TieBreak);

            HasRequired(r => r.Player1);
            HasRequired(r => r.Player2);
        }
    }
}
