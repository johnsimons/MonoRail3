namespace Castle.MonoRail.Mvc.Typed.Framework
{
    using System;
    using System.ComponentModel.Composition;

    [Export(typeof(IActionExecutionSink))]
    public class ActionExecutionSink : BaseControllerExecutionSink, IActionExecutionSink
    {
        public override void Invoke(ControllerExecutionContext executionCtx)
        {
            if (executionCtx.ActionMethod != null)
                executionCtx.ActionMethod.Invoke(executionCtx.Controller, null);
        }
    }
}
