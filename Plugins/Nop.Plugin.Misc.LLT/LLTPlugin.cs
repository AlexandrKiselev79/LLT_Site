using Nop.Core.Plugins;
using Nop.Plugin.Misc.LLT.Data;

namespace Nop.Plugin.Misc.LLT
{
    public class LLTPlugin : BasePlugin//, IAdminMenuPlugin
    {
        private readonly LLTObjectContext _context;

        public LLTPlugin(LLTObjectContext context)
        {
            _context = context;
        }

        public override void Install()
        {
            _context.Install();
            base.Install();
        }

        public override void Uninstall()
        {
            _context.Uninstall();
            base.Uninstall();
        }

        //public void ManageSiteMap(SiteMapNode rootNode)
        //{
        //    throw new NotImplementedException();
        //}

        //public bool Authenticate()
        //{
        //    return true;
        //}
    }
}
