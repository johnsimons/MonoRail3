namespace Layer2.Typed
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Reflection;
    using System.Web;
    using Castle.MonoRail.Mvc.Typed;

    [Export]
    public class TypedControllerExecutor : ControllerExecutor
    {
        public ControllerMeta Meta;

        [ImportMany]
        public IEnumerable<ExportFactory<IRequestSink, IRequestSinkConfig>> SinksFactory { get; set; }

        public override void Process(HttpContextBase context)
        {
            Contract.Assert(Meta != null);
            Contract.Assert(Meta.Metadata.ContainsKey("controller.action"));

            // not using buckets right now, based everything on ordering
            var result = SinksFactory.
                OrderBy(f => f.Metadata.Order).
                Select( f => f.CreateExport().Value ).ToList();

            if (result.Count == 0)
                // need (clearly) a better exception model
                throw new Exception("WTF?");

            // connect the sinks 
            for (int i = 0; i < result.Count - 1; i++)
            {
                result[i].Next = result[i + 1]; 
            }
            
            result[0].Invoke(new ActionInvocationContext(context, Meta.ControllerInstance, null));


//            var action = (string) Meta.Metadata["controller.action"];
//
//            var actionMethod = Meta.ControllerInstance.GetType().GetMethod(action, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
//
//            actionMethod.Invoke(Meta.ControllerInstance, new object[0]);
        }
    }
}
