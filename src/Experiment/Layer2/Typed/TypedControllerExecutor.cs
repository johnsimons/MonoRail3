namespace Layer2.Typed
{
    using System;
    using System.Web;

    public class TypedControllerExecutor : ControllerExecutor
    {
        public TypedControllerExecutor(object controller)
        {
        }

        public override void Process(HttpContextBase context)
        {
            throw new NotImplementedException();
        }
    }
}
