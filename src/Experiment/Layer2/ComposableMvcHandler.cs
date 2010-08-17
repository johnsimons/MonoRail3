namespace Layer2
{
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Web;
    using System.Web.Routing;
    using Layer1;

    [Export(typeof(IComposableHandler))]
    public class ComposableMvcHandler : ComposableHandler
    {
        [Import]
        public RequestParser Parser { get; set; }

        [ImportMany]
        public IEnumerable<ControllerProvider> ControllerProviders { get; set; }
        
        [ImportMany]
        public IEnumerable<ControllerExecutorProvider> ControllerExecutorProviders { get; set; }

        public override void ProcessRequest(HttpContextBase context)
        {
            RouteData data = Parser.ParseDescriminators(context.Request);

            ControllerMeta meta = InquiryProvidersForMetaController(data, context);

            if (meta == null)
                throw new HttpException(404, "Not found");

            ControllerExecutor executor = null;

            executor = GetExecutor(data, context, meta);

            if (executor == null)
                throw new HttpException(500, "Null executor ?!");

            executor.Process(context);
        }

        private ControllerExecutor GetExecutor(RouteData data, HttpContextBase context, ControllerMeta meta)
        {
            ControllerExecutor executor = null;

            foreach(var provider in ControllerExecutorProviders)
            {
                executor = provider.CreateExecutor(meta, data, context);
                if (executor != null) break;
            }
            
            return executor;
        }

        private ControllerMeta InquiryProvidersForMetaController(RouteData data, HttpContextBase context)
        {
            ControllerMeta meta = null;

            foreach(var provider in ControllerProviders)
            {
                meta = provider.Create(data, context);
                if (meta != null) break;
            }
            
            return meta;
        }
    }
}
