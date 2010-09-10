namespace Layer2.Typed
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Web;
    using System.Web.Routing;

    [PartCreationPolicy(CreationPolicy.Shared)]
    public class ReflectionBasedControllerProvider : ControllerProvider
    {
        private List<Tuple<string,Type>> _validTypes;

        [ImportingConstructor]
        public ReflectionBasedControllerProvider(IAssembliesSource source)
        {
            Contract.Requires(source != null);
            Contract.EndContractBlock();

            _validTypes = new List<Tuple<string, Type>>(
                source.Assemblies.SelectMany(a => a.GetTypes()).
                    Where(t => t.Name.EndsWith("Controller") && !t.IsAbstract).
                    Select(t => new Tuple<string, Type>(
                        t.Name.Substring(0, t.Name.Length - "Controller".Length).ToLowerInvariant(), t)));
        }

        // No side effects
        public override ControllerMeta Create(RouteData data, HttpContextBase context)
        {
            var controllerName = (string) data.Values["controller"]; //data.GetRequiredString("controller");

            if (controllerName == null)
                return null;

            var controllerType = _validTypes.
                Where(t => string.CompareOrdinal(t.Item1, controllerName) == 0).
                Select(t => t.Item2).FirstOrDefault();

            if (controllerType == null)
                return null;

            var controller = Activator.CreateInstance(controllerType);
            var meta = new ControllerMeta(controller);


            // Who should read the action - preferably only once
//            var action = (string)data.Values["action"];
//            meta.Metadata["controller.from"] = "simpletype";
//            meta.Metadata["controller.action"] = action;

            return meta;
        }
    }
}
