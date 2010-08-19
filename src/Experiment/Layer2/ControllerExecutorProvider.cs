namespace Layer2
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.Composition;
    using System.Web;
    using System.Web.Routing;

    [InheritedExport]
    public abstract class ControllerExecutorProvider
    {
		[ImportMany]
		public IEnumerable<Lazy<IRequestSink, IRequestSinkConfig>> AvailableRequestSinks { get; set; }

        public abstract ControllerExecutor CreateExecutor(ControllerMeta meta, RouteData data, HttpContextBase context);
    }
}
