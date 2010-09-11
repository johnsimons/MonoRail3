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
        private ICollection<ExportFactory<IActionResolutionSink>> _firstSinksFactory;
        private ICollection<ExportFactory<IAuthorizationSink>> _secondSinksFactory;
        private ICollection<ExportFactory<IPreActionExecutionSink>> _thirdSinksFactory;
        private ICollection<ExportFactory<IActionExecutionSink>> _forthSinksFactory;
        private ICollection<ExportFactory<IActionResultSink>> _fifthSinksFactory;

        [ImportingConstructor]
        public TypedControllerExecutor(
            [ImportMany] ICollection<ExportFactory<IActionResolutionSink>> firstSinksFactory,
            [ImportMany] ICollection<ExportFactory<IAuthorizationSink>> secondSinksFactory,
            [ImportMany] ICollection<ExportFactory<IPreActionExecutionSink>> thirdSinksFactory,
            [ImportMany] ICollection<ExportFactory<IActionExecutionSink>> forthSinksFactory,
            [ImportMany] ICollection<ExportFactory<IActionResultSink>> fifthSinksFactory)
        {
            _firstSinksFactory = firstSinksFactory;
            _secondSinksFactory = secondSinksFactory;
            _thirdSinksFactory = thirdSinksFactory;
            _forthSinksFactory = forthSinksFactory;
            _fifthSinksFactory = fifthSinksFactory;
        }

        public ControllerMeta Meta;

        public override void Process(HttpContextBase context)
        {
            Contract.Assert(Meta != null);
            
            var first = CreateAndConnectSinks(_fifthSinksFactory, null);
            first = CreateAndConnectSinks(_forthSinksFactory, first);
            first = CreateAndConnectSinks(_thirdSinksFactory, first);
            first = CreateAndConnectSinks(_secondSinksFactory, first);
            first = CreateAndConnectSinks(_firstSinksFactory, first);

            if (first == null)
                // need exception model
                throw new Exception("No sink for action resolution?");

            var invocationCtx = new ControllerExecutionContext(context, Meta.ControllerInstance, null);
            first.Invoke(invocationCtx);

        }

        private static IControllerExecutionSink
            CreateAndConnectSinks<T>(ICollection<ExportFactory<T>> list, IControllerExecutionSink previousFirst)
            where T : class, IControllerExecutionSink
        {
            T prev = null;
            T first = null;

            foreach(var sinkFactory in list)
            {
                var sink = sinkFactory.CreateExport().Value;

                if (prev != null)
                    prev.Next = sink;

                if (first == null)
                    first = sink;

                prev = sink;
            }

            if (previousFirst != null && prev != null)
                prev.Next = previousFirst;

            return first ?? previousFirst;
        }
    }
}
