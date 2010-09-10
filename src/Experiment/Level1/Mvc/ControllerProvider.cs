namespace Layer2
{
    using System.ComponentModel.Composition;
    using System.Web;
    using System.Web.Routing;

    [InheritedExport]
    public abstract class ControllerProvider
    {
        public abstract ControllerMeta Create(RouteData data, HttpContextBase context);
    }
}
