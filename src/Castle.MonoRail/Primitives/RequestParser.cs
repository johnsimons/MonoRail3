namespace Castle.MonoRail.Primitives
{
    using System.ComponentModel.Composition;
    using System.Web;
    using System.Web.Routing;

    [Export]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class RequestParser
    {
        public RouteData ParseDescriminators(HttpRequestBase request)
        {
            return request.RequestContext.RouteData;
        }
    }
}
