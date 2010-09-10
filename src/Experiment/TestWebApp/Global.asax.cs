using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace TestWebApp
{
    using System.Web.Routing;
    using Layer1.Mvc;

    public class Global : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            // routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.Add(
                new Route("{controller}/{action}/{id}",
                     new RouteValueDictionary(new { controller = "home", action = "index", id = "" }),
                     new MvcRouteHandler()));
        }

        void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes(RouteTable.Routes);

        }

        void Application_End(object sender, EventArgs e)
        {
        }

        void Application_Error(object sender, EventArgs e)
        {
        }
    }
}
