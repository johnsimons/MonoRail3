namespace TestWebApp
{
    using System;
    using System.Web.Routing;
    using Castle.MonoRail.Hosting.Mvc;

    public class Global : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
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
