namespace Castle.MonoRail.Hosting.Mvc.Typed
{
    using System.Reflection;
    using System.Web;
    using System.Web.Routing;
    using Internal;

    public sealed class ControllerExecutionContext
    {
        internal ControllerExecutionContext(HttpContextBase httpContext, 
            object controller, RouteData data, 
            ControllerDescriptor controllerDescriptor)
        {
            this.HttpContext = httpContext;
            this.Controller = controller;
            this.RouteData = data;
            ControllerDescriptor = controllerDescriptor;
        }

        // readonly
        public object Controller { get; private set; }
        public HttpContextBase HttpContext { get; private set; }
        public RouteData RouteData { get; private set; }
        public ControllerDescriptor ControllerDescriptor { get; private set; }

        public ActionDescriptor SelectedAction { get; set; }
    }
}