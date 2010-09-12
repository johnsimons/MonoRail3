namespace Castle.MonoRail.Hosting.Mvc.Typed.Internal
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Linq;
    using System.Reflection;
    using System.Web.Compilation;

    [Export(typeof(IAssembliesSource))]
    [Export(typeof(IWebFormFactory))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class BuildManagerWrap : IAssembliesSource, IWebFormFactory
    {
        public object CreateInstanceFromVirtualPath(string path, Type baseType)
        {
            return BuildManager.CreateInstanceFromVirtualPath(path, baseType);
        }

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