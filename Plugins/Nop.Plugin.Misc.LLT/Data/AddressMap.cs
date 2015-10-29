using System.Data.Entity.ModelConfiguration;
using Nop.Plugin.Misc.LLT.Domain;

namespace Nop.Plugin.Misc.LLT.Data
{
    public class AddressMap : EntityTypeConfiguration<Address>
    {
        public AddressMap()
        {
            ToTable(TablesName.AddressTable);
            HasKey(m => m.Id);

            Property(m => m.Country);
            Property(m => m.City);
            Property(m => m.Line1);
            Property(m => m.Line2);
            Property(m => m.ZipCode);
            Property(m => m.Phone);
            Property(m => m.Deleted);
        }
    }
}
