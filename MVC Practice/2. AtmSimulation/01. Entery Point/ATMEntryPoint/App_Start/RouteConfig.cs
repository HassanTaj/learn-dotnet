using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ATMEntryPoint {
    public class RouteConfig {
        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // custom rout for Shit with request Query
            routes.MapRoute(
              name: "Shit number",
              url: "shit",
             defaults: new { controller = "Home", action = "Shit" }
            );

            // custom rout for Serial
            routes.MapRoute(
              name: "Serial number",
              url: "serial/{letterCase}",
             defaults: new { controller = "Home", action = "Serial", letterCase = "upper" }
            );


            // default Route
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}
