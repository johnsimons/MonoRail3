namespace Castle.MonoRail.Hosting.Mvc.Internal
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    public interface IHostingBridge
    {
        IEnumerable<Assembly> ReferenceAssemblies { get; }

        bool FileExists(string virtualPath);
        
        Type GetCompiledType(string virtualPath);
    }
}