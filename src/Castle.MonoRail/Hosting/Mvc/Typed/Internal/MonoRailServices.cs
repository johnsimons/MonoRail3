namespace Castle.MonoRail.Hosting.Mvc.Typed.Internal
{
    using System.Collections.Generic;
    using System.ComponentModel.Composition;

    [Export(typeof(IMonoRailServices))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class MonoRailServices : IMonoRailServices
    {
        [Import]
        public CompositeViewEngine ViewEngines { get; set; }
    }
}
