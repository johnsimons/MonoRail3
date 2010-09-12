namespace Castle.MonoRail.Hosting
{
    using System.ComponentModel.Composition.Hosting;
    using System.ComponentModel.Composition;
    using System.Diagnostics;
    using System.Web;
    using Internal;

    public abstract class ComposableHandler : IHttpHandler /*IHttpAsyncHandler*/, IComposableHandler
    {
        public abstract void ProcessRequest(HttpContextBase context);

#if DEBUG
        private Stopwatch _watch = new Stopwatch();
#endif

        // non-disposables being added to container: fine
        // no state changes
        void IHttpHandler.ProcessRequest(HttpContext context)
        {
#if DEBUG
            _watch.Reset();
#endif
            var batch = new CompositionBatch();
            batch.AddPart(this);
            ContainerManager.GetRequestContainer().Compose(batch);
#if DEBUG
            _watch.Stop();
            Debugger.Log(1, "Perf", "Handler composition took " + _watch.ElapsedMilliseconds + " ms");
#endif

            ProcessRequest(new HttpContextWrapper(context));
        }

        bool IHttpHandler.IsReusable
        {
            get { return true; }
        }

//        IAsyncResult IHttpAsyncHandler.BeginProcessRequest(HttpContext context, AsyncCallback cb, object extraData)
//        {
//            throw new NotImplementedException();
//        }
//
//        void IHttpAsyncHandler.EndProcessRequest(IAsyncResult result)
//        {
//            
//        }
    }
}
