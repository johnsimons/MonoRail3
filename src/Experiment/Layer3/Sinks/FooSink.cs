namespace Layer3.Sinks
{
	using System;
	using System.ComponentModel.Composition;
	using Layer2;

	[Export(typeof(IRequestSink))]
	[RequestSinkConfig(Order = 1)]
	public class FooSink  : IRequestSink
	{
		public void Invoke(InvocationContext context)
		{
			context.HttpContext.Items["text"] = "monorail";
		}
	}
}
