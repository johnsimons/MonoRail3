namespace Layer3.Sinks
{
	using System;
	using System.ComponentModel.Composition;
	using Layer2;

	[Export(typeof(IRequestSink))]
	[RequestSinkConfig(Order = 1)]
	public class FooSink  : IRequestSink
	{
		public IRequestSink Next { get; set; }

		public void Invoke(InvocationContext context)
		{
			context.HttpContext.Items["text"] = "monorail";

			if (Next != null) Next.Invoke(context);
		}
	}
}
