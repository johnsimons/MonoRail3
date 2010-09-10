namespace Layer1.Mvc
{
    using System;
    using System.Web;
    using System.Web.Routing;
    using Layer2;

    public class MvcRouteHandler : IRouteHandler
    {
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return new ComposableMvcHandler();
        }
    }
}
