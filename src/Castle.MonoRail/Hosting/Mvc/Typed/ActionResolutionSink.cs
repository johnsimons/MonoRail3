namespace Castle.MonoRail.Framework
{
    using System;
    using System.ComponentModel.Composition;
    using System.Reflection;

    [Export(typeof(IActionResolutionSink))]
    public class ActionResolutionSink : BaseControllerExecutionSink, IActionResolutionSink
    {
        private const BindingFlags flags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase;

        public override void Invoke(ControllerExecutionContext executionCtx)
        {
            var action = executionCtx.RouteData.GetRequiredString("action");
            var instance = executionCtx.Controller;

            var actionMethod = instance.GetType().GetMethod(action, flags);
            executionCtx.ActionMethod = actionMethod;

            Proceed(executionCtx);
        }
    }
}
