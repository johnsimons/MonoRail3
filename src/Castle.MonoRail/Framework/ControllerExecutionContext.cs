namespace Castle.MonoRail.Framework
{
    using System.Reflection;
    using System.Web;
    using System.Web.Routing;

    public sealed class ControllerExecutionContext
    {
        internal ControllerExecutionContext(HttpContextBase httpContext, object controller, RouteData data)
        {
            this.HttpContext = httpContext;
            this.Controller = controller;
            this.RouteData = data;
        }

        public MethodInfo ActionMethod { get; set; }

        public HttpContextBase HttpContext { get; private set; }

        public object Controller { get; private set; }

        public RouteData RouteData { get; private set; }
    }
}