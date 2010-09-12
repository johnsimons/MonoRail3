namespace Castle.MonoRail.Hosting.Mvc.Typed
{
    using System;
    using System.ComponentModel.Composition;

    [Export(typeof(IActionExecutionSink))]
    public class ActionExecutionSink : BaseControllerExecutionSink, IActionExecutionSink
    {
        public override void Invoke(ControllerExecutionContext executionCtx)
        {
            executionCtx.SelectedAction.Action(executionCtx.Controller, new object[0]);
        }
    }
}
