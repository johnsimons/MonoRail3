namespace Layer2.Typed
{
    using System.Linq;
    using System.Web;
    using System.Web.Routing;

    public class TypedControllerExecutorProvider : ControllerExecutorProvider
    {
        public override ControllerExecutor CreateExecutor(ControllerMeta meta, RouteData data, HttpContextBase context)
        {
            return new TypedControllerExecutor(meta.ControllerInstance, data){RequestSink = BuildSink()};
        }

    	private IRequestSink BuildSink()
    	{
    		var ordered = AvailableRequestSinks.OrderByDescending(lazy => lazy.Metadata.Order).Select(lazy => lazy.Value);

    		IRequestSink head = null;

			foreach (var sink in ordered)
			{
				sink.Next = head;

				head = sink;
			}

    		return head;
    	}
    }
}
