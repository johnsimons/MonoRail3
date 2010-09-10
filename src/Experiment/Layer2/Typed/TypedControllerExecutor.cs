namespace Layer2.Typed
{
    using System.Web;
    using System.Web.Routing;

	public class TypedControllerExecutor : ControllerExecutor
    {
    	private readonly object controller;
		private readonly RouteData data;

		public TypedControllerExecutor(object controller, RouteData data)
    	{
    		this.controller = controller;
    		this.data = data;
    	}

		public override void Process(HttpContextBase context)
    	{
    		var invocationCtx = new InvocationContext {HttpContext = context, Controller = controller, RouteData = data};

			RequestSink.Invoke(invocationCtx);
    	}
    }
}
