using Nop.Core;

namespace Nop.Plugin.Misc.LLT.Domain
{
    public class Player: BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Rating { get; set; }
    }
}
