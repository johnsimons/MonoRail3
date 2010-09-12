namespace Castle.MonoRail.Framework.Internal
{
    using System.Collections.Generic;
    using System.Reflection;

    public interface IAssembliesSource
    {
        IEnumerable<Assembly> Assemblies { get; }
    }
}