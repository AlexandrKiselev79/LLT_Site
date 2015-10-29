using System.Collections.Generic;
using Nop.Core;
using Nop.Plugin.Misc.LLT.Enums;

namespace Nop.Plugin.Misc.LLT.Domain
{
    public class TennisClub: BaseEntity
    {
        public TennisClub()
        {
            Deleted = false;
        }

        public string Name { get; set; }

        public Address Address { get; set; }

        public string Email { get; set; }

        public string Description { get; set; }

        public Dictionary<CourtType, int> Courts { get; set; }

        public string CourtsAsJSON
        {
            get { return string.Empty; }
            set { Courts = new Dictionary<CourtType, int>();}
        }

        public bool Deleted { get; set; }
    }
}
