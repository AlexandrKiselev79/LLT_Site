using System.Data.Entity;
using Nop.Core.Infrastructure;
using Nop.Plugin.Misc.LLT.Data;

namespace Nop.Plugin.Misc.LLT.Infrastructure
{
    public class EfStartUpTask : IStartupTask
    {
        public void Execute()
        {
            Database.SetInitializer<LLTObjectContext>(null);
        }

        public int Order
        {
            get { return 0; }
        }
    }
}
