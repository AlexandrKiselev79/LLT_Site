using System.Web.Mvc;
using System.Web.Routing;
using Nop.Core.Fakes;
using Nop.Plugin.Misc.LLT.Infrastructure;
using Nop.Web.Framework.Localization;
using Nop.Web.Framework.Mvc.Routes;

namespace Nop.Plugin.Misc.LLT
{
    public partial class RouteProvider : IRouteProvider
    {
        private const string CONTROLLERS_NAMESPACE = "Nop.Plugin.Misc.LLT.Controllers";

        public void RegisterRoutes(RouteCollection routes)
        {
            ViewEngines.Engines.Insert(0, new CustomViewEngine());

            routes.MapRoute("Plugin.Misc.LLT.ViewRegulations",
                "Regulations/",
                new { controller = "LLTHome", action = "Regulations" },
                new[] { CONTROLLERS_NAMESPACE });

            routes.MapRoute("Plugin.Misc.LLT.ViewRating",
                "Rating/",
                new { controller = "LLTHome", action = "Rating" },
                new[] { CONTROLLERS_NAMESPACE });

            routes.MapRoute("Plugin.Misc.LLT.ViewCourts",
                "Courts/",
                new { controller = "LLTHome", action = "Courts" },
                new[] { CONTROLLERS_NAMESPACE });

            routes.MapRoute("Plugin.Misc.LLT.ViewClubs",
                "Clubs/",
                new { controller = "Club", action = "List" },
                new[] { CONTROLLERS_NAMESPACE });

            routes.MapRoute("Plugin.Misc.LLT.ViewPlayers",
                "Players/",
                new { controller = "Player", action = "List"},
                new[] { CONTROLLERS_NAMESPACE });

            routes.MapRoute("Plugin.Misc.LLT.ViewHead2Head",
                "Head2Head/",
                new { controller = "Player", action = "Head2Head" },
                new[] { CONTROLLERS_NAMESPACE });

            routes.MapRoute("Plugin.Misc.LLT.ViewTournaments",
                "Tournaments/",
                new { controller = "Tournament", action = "List"},
                new[] { CONTROLLERS_NAMESPACE });

            routes.MapRoute("Plugin.Misc.LLT.ViewNews",
                "News/",
                new { controller = "LLTNews", action = "List" },
                new[] { CONTROLLERS_NAMESPACE });

            var routeDate = routes.GetRouteData(new FakeHttpContext("~/players"));
            routeDate = routes.GetRouteData(new FakeHttpContext("~/tournaments"));

            //LLT home page
            UpdateRoute(routes, "HomePage", "", "LLTHome", "Index", CONTROLLERS_NAMESPACE);
            //UpdateRoute(routes, "News", "", "LLTNews", "List", CONTROLLERS_NAMESPACE);
            //UpdateRoute(routes, "NewsItem", "", "LLTNews", "NewsItem", CONTROLLERS_NAMESPACE);
        }

        public int Priority
        {
            get
            {
                return 0;
            }
        }

        private void UpdateRoute(RouteCollection routes, string routeName,
            string url, string controllerName, string actionName, string namespaces)
        {
            var route = routes[routeName] as LocalizedRoute;
            if (route != null)
            {
                routes.Remove(route);
            }
            routes.MapLocalizedRoute(routeName, url, new { controller = controllerName, action = actionName },
                new[] { namespaces });
        }

    }
}
