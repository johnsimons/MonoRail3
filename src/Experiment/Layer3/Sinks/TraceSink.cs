namespace Layer3.Sinks
{
	using System.ComponentModel.Composition;
	using System.Diagnostics;
	using Layer2;

	[Export(typeof(IRequestSink))]
	[RequestSinkConfig(Order = 5)]
	public class TraceSink : IRequestSink
	{
		public IRequestSink Next { get; set; }

		public void Invoke(InvocationContext context)
		{
			var watch = new Stopwatch();

			try
			{
				watch.Start();

				Next.Invoke(context);
			}
			finally
			{
				watch.Stop();

				context.HttpContext.Response.Write("<br /> executed: " + watch.ElapsedTicks + " ticks");
			}
		
		}
	}
}
