using System;
using Nop.Core;

namespace Nop.Plugin.Misc.LLT.Domain
{
    public class PlayerResult : BaseEntity
    {
        public virtual Tournament Tournament { get; set; }

        public virtual Player Player { get; set; }

        public int Place { get; set; }

        public int Points { get; set; }

        public DateTime DateTime { get; set; }
    }
}
