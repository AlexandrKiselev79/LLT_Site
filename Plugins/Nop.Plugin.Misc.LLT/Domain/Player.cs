using System;
using Nop.Core;

namespace Nop.Plugin.Misc.LLT.Domain
{
    public class Player: BaseEntity
    {
        public Player()
        {
            ForehandRight = true;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string City { get; set; }

        public bool ForehandRight { get; set; }

        public decimal Height { get; set; }

        public decimal Weight { get; set; }
    }
}
