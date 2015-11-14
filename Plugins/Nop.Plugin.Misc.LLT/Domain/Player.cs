using System;
using Nop.Core;
using Nop.Plugin.Misc.LLT.Enums;

namespace Nop.Plugin.Misc.LLT.Domain
{
    public class Player: BaseEntity
    {
        public Player()
        {
            ForehandRight = true;
            Deleted = false;
            Gender = GenderType.Man;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string City { get; set; }

        public bool ForehandRight { get; set; }

        public GenderType Gender { get; set; }

        public decimal Height { get; set; }

        public decimal Weight { get; set; }

        public bool Deleted { get; set; }
    }
}
