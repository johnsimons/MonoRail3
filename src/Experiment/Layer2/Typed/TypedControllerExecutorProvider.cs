namespace Layer2.Typed
{
    using System;
    using System.Web;

    public class TypedControllerExecutorProvider : ControllerExecutorProvider
    {
        public override ControllerExecutor CreateExecutor(ControllerMeta meta, HttpContextBase context)
        {
            throw new NotImplementedException();
        }
    }
}
