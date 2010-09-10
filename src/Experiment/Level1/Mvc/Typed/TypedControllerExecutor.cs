namespace Layer2.Typed
{
    using System;
    using System.ComponentModel.Composition;
    using System.Diagnostics.Contracts;
    using System.Reflection;
    using System.Web;
    using System.Web.Routing;

    [Export]
    public class TypedControllerExecutor : ControllerExecutor
    {
        public ControllerMeta Meta;

        public override void Process(HttpContextBase context)
        {
            Contract.Assert(Meta != null);
            Contract.Assert(Meta.Metadata.ContainsKey("controller.action"));

            var action = (string) Meta.Metadata["controller.action"];

            var actionMethod = Meta.ControllerInstance.GetType().GetMethod(action, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);

            actionMethod.Invoke(Meta.ControllerInstance, new object[0]);
        }
    }
}
