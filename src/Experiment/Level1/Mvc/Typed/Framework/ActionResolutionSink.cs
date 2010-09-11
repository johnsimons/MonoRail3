namespace Castle.MonoRail.Mvc.Typed
{
    using System;
    using System.ComponentModel.Composition;

    [Export(typeof(IActionResolutionSink))]
    public class ActionResolutionSink : BaseControllerExecutionSink, IActionResolutionSink
    {
        public override void Invoke(ControllerExecutionContext executionCtx)
        {
//            var action = (string) Meta.Metadata["controller.action"];
//
//            var actionMethod = Meta.ControllerInstance.GetType().GetMethod(action, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
//
//            actionMethod.Invoke(Meta.ControllerInstance, new object[0]);

        }
    }
}
