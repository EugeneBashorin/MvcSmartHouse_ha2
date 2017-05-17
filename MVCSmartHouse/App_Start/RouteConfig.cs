using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVCSmartHouse
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}/{command}/{butData}",
                defaults: new { controller = "SmartHouse", action = "Index", id = UrlParameter.Optional, command = UrlParameter.Optional, butData = UrlParameter.Optional }
            );
        }
    }
}
