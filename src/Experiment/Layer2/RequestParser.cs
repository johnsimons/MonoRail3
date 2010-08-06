namespace Layer2
{
    using System.ComponentModel.Composition;
    using System.Web;
    using System.Web.Routing;

    [Export]
    public class RequestParser
    {
        public RouteData ParseDescriminators(HttpRequestBase request)
        {
            return request.RequestContext.RouteData;
        }
    }
}
