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
            var lltMenuItem = new SiteMapNode()
            {
                Title = "LLT",
                Url = "/PlayerAdmin/List",
                Visible = true,
                RouteValues = new RouteValueDictionary() { { "Area", "Admin" } }
            };

            var playersMenuUtem = new SiteMapNode()
            {
                SystemName = "LLT",
                Title = "Players",
                Url = "/PlayerAdmin/List",
                Visible = true,
                RouteValues = new RouteValueDictionary() { { "Area", "Admin" } }
            };
            lltMenuItem.ChildNodes.Add(playersMenuUtem);

            var tournamentsMenuUtem = new SiteMapNode()
            {
                SystemName = "LLT",
                Title = "Tournaments",
                Url = "/TournamentAdmin/List",
                Visible = true,
                RouteValues = new RouteValueDictionary() { { "Area", "Admin" } }
            };
            lltMenuItem.ChildNodes.Add(tournamentsMenuUtem);

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
                pluginNode.ChildNodes.Add(lltMenuItem);
            else
                rootNode.ChildNodes.Add(lltMenuItem);

        }

        public bool Authenticate()
        {
            return true;
        }
    }
}
