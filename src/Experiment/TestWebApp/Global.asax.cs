namespace TestWebApp
{
	using System;
	using System.Web;
	using System.Web.Routing;
	using Layer2;

	public class Global : System.Web.HttpApplication
    {
		protected void Application_Start()
		{
			RouteTable.Routes.Add("default", new Route("{controller}/{action}", new RouteHandler()));
		}
    }

	public class RouteHandler : IRouteHandler
	{
		public IHttpHandler GetHttpHandler(RequestContext requestContext)
		{
			return new ComposableMvcHandler();
		}
	}
}
