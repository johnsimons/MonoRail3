namespace Layer2.Typed
{
    using System;
    using System.Web;
    using System.Web.Routing;

    public class TypedControllerExecutorProvider : ControllerExecutorProvider
    {
        public override ControllerExecutor CreateExecutor(ControllerMeta meta, RouteData data, HttpContextBase context)
        {
            throw new NotImplementedException();
        }
    }
}
