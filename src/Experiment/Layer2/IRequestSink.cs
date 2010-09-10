namespace Layer2
{
	using System;
	using System.ComponentModel.Composition;
	using System.Web;
	using System.Web.Routing;

	public interface IRequestSink
	{
		IRequestSink Next { get; set; }

		void Invoke(InvocationContext invocationCtx);
	}

	public interface IRequestSinkConfig
	{
		int Order { get; }
	}

	[MetadataAttribute]
	public class RequestSinkConfigAttribute : Attribute
	{
		public int Order { get; set; }
	}

	public class InvocationContext
	{
		public HttpContextBase HttpContext { get; set; }

		public object Controller { get; set; }

		public RouteData RouteData { get; set; }
	}
}
