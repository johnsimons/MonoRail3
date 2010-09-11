namespace Castle.MonoRail.Mvc.Typed.Framework.Internal
{
    using System.Collections.Generic;
    using System.Reflection;

    public interface IAssembliesSource
    {
        IEnumerable<Assembly> Assemblies { get; }
    }
}