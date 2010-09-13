namespace Castle.MonoRail.Hosting.Mvc.Internal
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Linq;
    using System.Reflection;
    using System.Web.Compilation;
    using Typed.Internal;

    [Export(typeof(IHostingBridge))]
    [Export(typeof(IWebFormFactory))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class BuildManagerWrap : IHostingBridge, IWebFormFactory
    {
        public object CreateInstanceFromVirtualPath(string path, Type baseType)
        {
            return BuildManager.CreateInstanceFromVirtualPath(path, baseType);
        }

        public bool FileExists(string virtualPath)
        {
            return (BuildManager.GetObjectFactory(virtualPath, false) != null);
        }

        public Type GetCompiledType(string virtualPath)
        {
            return BuildManager.GetCompiledType(virtualPath);
        }

        public IEnumerable<Assembly> ReferenceAssemblies
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