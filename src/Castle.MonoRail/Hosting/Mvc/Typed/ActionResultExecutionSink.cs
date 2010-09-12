namespace Castle.MonoRail.Hosting.Mvc.Typed
{
    using System.ComponentModel.Composition;

    [Export(typeof(IActionResultSink))]
    public class ActionResultExecutionSink : BaseControllerExecutionSink, IActionResultSink
    {
        [Import]
        public IMonoRailServices Services { get; set; }

        public override void Invoke(ControllerExecutionContext executionCtx)
        {
            var result = executionCtx.InvocationResult as ActionResult;

            if (result != null)
            {
                var areaName = executionCtx.ControllerDescriptor.Area;
                var controllerName = executionCtx.ControllerDescriptor.Name;
                var actionName = executionCtx.SelectedAction.Name;

                var resultCtx = new ActionResultContext(areaName, controllerName, actionName);

                result.Execute(resultCtx, this.Services);
            }

            Proceed(executionCtx);
        }
    }
}
