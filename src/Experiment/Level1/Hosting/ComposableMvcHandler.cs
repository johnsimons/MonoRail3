namespace Castle.MonoRail.Hosting
{
    using System.ComponentModel.Composition;
    using System.Diagnostics.Contracts;
    using System.Web;
    using System.Web.Routing;
    using Primitives;

    [Export(typeof(IComposableHandler))]
    public class ComposableMvcHandler : ComposableHandler
    {
        [Import]
        public RequestParser Parser { get; set; }

        [Import]
        public PipelineRunner Runner { get; set; }

        // no state changes
        // what exceptions we should guard against?
        public override void ProcessRequest(HttpContextBase context)
        {
            Contract.Requires(context != null);
            Contract.EndContractBlock();

            RouteData data = Parser.ParseDescriminators(context.Request);

            Runner.Process(data, context);
        }
    }
}
