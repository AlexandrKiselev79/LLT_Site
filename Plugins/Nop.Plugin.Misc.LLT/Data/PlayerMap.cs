using System.Data.Entity.ModelConfiguration;
using Nop.Plugin.Misc.LLT.Domain;

namespace Nop.Plugin.Misc.LLT.Data
{
    public class PlayerMap : EntityTypeConfiguration<Player>
    {
        public PlayerMap()
        {
            ToTable(TablesName.PlayerTable);
            HasKey(m => m.Id);

            Property(m => m.FirstName);
            Property(m => m.LastName);
            Property(m => m.MiddleName);
            Property(m => m.DateOfBirth);
            Property(m => m.City);
            Property(m => m.ForehandRight);
            Property(m => m.Gender);
            Property(m => m.Height);
            Property(m => m.Weight);
            Property(m => m.Deleted);
        }
    }
}
