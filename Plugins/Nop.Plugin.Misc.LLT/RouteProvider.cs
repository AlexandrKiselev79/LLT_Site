using System.Web.Mvc;
using System.Web.Routing;
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

            //LLT home page
            UpdateRoute(routes, "HomePage", "", "LLTHome", "Index", CONTROLLERS_NAMESPACE);
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
