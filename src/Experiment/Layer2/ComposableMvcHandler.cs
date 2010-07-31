namespace Layer2
{
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Web;
    using Level1;

    public class ComposableMvcHandler : ComposableHandler
    {
        [ImportMany]
        public IEnumerable<ControllerProvider> ControllerProviders { get; set; }
        
        [ImportMany]
        public IEnumerable<ControllerExecutorProvider> ControllerExecutorProviders { get; set; }

        public override void ProcessRequest(HttpContextBase context)
        {
            ControllerMeta meta = InquiryProvidersForMetaController(context);

            if (meta == null)
                throw new HttpException(404, "Not found");

            ControllerExecutor executor = null;

            executor = GetExecutor(context, meta, executor);

            if (executor == null)
                throw new HttpException(500, "Null executor ?!");

            executor.Process(context);
        }

        private ControllerExecutor GetExecutor(HttpContextBase context, ControllerMeta meta, ControllerExecutor executor)
        {
            foreach(var provider in ControllerExecutorProviders)
            {
                executor = provider.CreateExecutor(meta, context);
                if (executor != null) break;
            }
            
            return executor;
        }

        private ControllerMeta InquiryProvidersForMetaController(HttpContextBase context)
        {
            ControllerMeta meta = null;

            foreach(var provider in ControllerProviders)
            {
                meta = provider.Create(context);
                if (meta != null) break;
            }
            
            return meta;
        }
    }
}
