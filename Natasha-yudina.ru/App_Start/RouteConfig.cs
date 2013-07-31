using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Natasha_yudina.ru
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{project}/{id}",
                defaults: new { controller = "Home", action = "Index", project = UrlParameter.Optional, id = UrlParameter.Optional }
            );
        }
    }
}