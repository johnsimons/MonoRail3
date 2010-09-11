namespace Castle.MonoRail.Mvc.Typed.Framework.Internal
{
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Linq;
    using System.Reflection;
    using System.Web.Compilation;

    [Export(typeof(IAssembliesSource))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class BuildManagerAssembliesSource : IAssembliesSource
    {
        public IEnumerable<Assembly> Assemblies
        {
            // should it lazy initialize a field value?
            // can more assemblies be added to this list in runtime?
            get
            {
                var assemblies = BuildManager.GetReferencedAssemblies();
                return Enumerable.Cast<Assembly>(assemblies);
            }
        }
    }
}