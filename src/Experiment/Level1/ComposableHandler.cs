namespace Layer1
{
    using System;
    using System.ComponentModel.Composition.Hosting;
    using System.ComponentModel.Composition;
    using System.Diagnostics;
    using System.Web;
    using Internal;

    public abstract class ComposableHandler : IHttpHandler /*IHttpAsyncHandler*/, IComposableHandler
    {
        public abstract void ProcessRequest(HttpContextBase context);

#if DEBUG
        Stopwatch watch = new Stopwatch();
#endif

        void IHttpHandler.ProcessRequest(HttpContext context)
        {
#if DEBUG
            watch.Reset();
#endif
            var batch = new CompositionBatch();
            batch.AddPart(this);
            ContainerHolder.GetOrCreate().Compose(batch);
#if DEBUG
            watch.Stop();
            Debugger.Log(1, "Perf", "Handler composition took " + watch.ElapsedMilliseconds + " ms");
#endif

            ProcessRequest(new HttpContextWrapper(context));
        }

        bool IHttpHandler.IsReusable
        {
            get { return false; }
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
