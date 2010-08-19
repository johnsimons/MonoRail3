namespace Layer3.Sinks
{
	using System;
	using System.ComponentModel.Composition;
	using System.Reflection;
	using System.Web;
	using Layer2;

	[Export(typeof(IRequestSink))]
	[RequestSinkConfig(Order = 2)]
	public class InvokeActionMethodSink : IRequestSink
	{
		public void Invoke(InvocationContext context)
		{
			var method = context.Controller.GetType().GetMethod(context.RouteData.GetRequiredString("action"), BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

			if (method == null)
				throw new HttpException(404, "Not found");

			method.Invoke(context.Controller, new object[] {context.HttpContext});
		}
	}
}
