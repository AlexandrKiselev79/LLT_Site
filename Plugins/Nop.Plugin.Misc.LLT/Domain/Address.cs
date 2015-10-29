using Nop.Core;

namespace Nop.Plugin.Misc.LLT.Domain
{
    public class Address: BaseEntity
    {
        public Address()
        {
            Deleted = false;
        }

        public string Country { get; set; }

        public string City { get; set; }

        public string Line1 { get; set; }

        public string Line2 { get; set; }

        public string ZipCode { get; set; }

        public string Phone { get; set; }

        public bool Deleted { get; set; }
    }
}
