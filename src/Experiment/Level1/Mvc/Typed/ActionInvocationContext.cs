namespace Castle.MonoRail.Mvc.Typed
{
    using System.Web;
    using System.Web.Routing;

    public sealed class ActionInvocationContext
    {
        internal ActionInvocationContext(HttpContextBase httpContext, object controller, RouteData data)
        {
            this.HttpContext = httpContext;
            this.Controller = controller;
            this.RouteData = data;
        }

        public HttpContextBase HttpContext { get; private set; }

        public object Controller { get; private set; }

        public RouteData RouteData { get; private set; }
    }
}