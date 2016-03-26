using System;
using System.Linq;
using System.Web.Routing;
using Nop.Core.Plugins;
using Nop.Plugin.Misc.LLT.Data;
using Nop.Web.Framework.Menu;

namespace Nop.Plugin.Misc.LLT
{
    public class LLTPlugin : BasePlugin, IAdminMenuPlugin
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

        public void ManageSiteMap(SiteMapNode rootNode)
        {
            var playerMenuItem = new SiteMapNode()
            {
                Title = "LLT",
                Url = "/PlayerAdmin/List",
                Visible = true,
                RouteValues = new RouteValueDictionary() { { "Area", "Admin" } }
            };

            var rolesSponsorsMenuItem = new SiteMapNode()
            {
                SystemName = "LLT",
                Title = "Players",
                Url = "/PlayerAdmin/List",
                Visible = true,
                RouteValues = new RouteValueDictionary() { { "Area", "Admin" } }
            };
            playerMenuItem.ChildNodes.Add(rolesSponsorsMenuItem);

            //var excludedFromDefaultMenuItem = new SiteMapNode()
            //{
            //    SystemName = "VirginPulse",
            //    Title = "Excluded from Default Role",
            //    Url = "/Shop/ExcludedFromDefault/ManageExcluded",
            //    Visible = true,
            //    RouteValues = new RouteValueDictionary() { { "Area", "Admin" } }
            //};
            //virginPulseMenuItem.ChildNodes.Add(excludedFromDefaultMenuItem);

            var pluginNode = rootNode.ChildNodes.FirstOrDefault(x => x.SystemName == "Third party plugins");
            if (pluginNode != null)
                pluginNode.ChildNodes.Add(playerMenuItem);
            else
                rootNode.ChildNodes.Add(playerMenuItem);

        }

        public bool Authenticate()
        {
            return true;
        }
    }
}
