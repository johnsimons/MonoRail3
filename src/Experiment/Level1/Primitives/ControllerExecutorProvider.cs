namespace Castle.MonoRail.Primitives
{
	using System.ComponentModel.Composition;
	using System.Web;
	using System.Web.Routing;

	public abstract class ControllerExecutorProvider
	{
		public abstract ControllerExecutor CreateExecutor(ControllerMeta meta, RouteData data, HttpContextBase context);
	}
}
