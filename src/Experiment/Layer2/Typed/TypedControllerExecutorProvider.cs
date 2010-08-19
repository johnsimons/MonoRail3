namespace Layer2.Typed
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Routing;

    public class TypedControllerExecutorProvider : ControllerExecutorProvider
    {
        public override ControllerExecutor CreateExecutor(ControllerMeta meta, RouteData data, HttpContextBase context)
        {
            return new TypedControllerExecutor(meta.ControllerInstance, data){RequestSink = GetOrderedSink()};
        }

    	private IEnumerable<IRequestSink> GetOrderedSink()
    	{
    		return AvailableRequestSinks.OrderBy(lazy => lazy.Metadata.Order).Select(lazy => lazy.Value);
    	}
    }
}
