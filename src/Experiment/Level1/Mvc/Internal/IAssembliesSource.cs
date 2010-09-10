namespace Layer2.Typed
{
    using System.Collections.Generic;
    using System.Reflection;

    public interface IAssembliesSource
    {
        IEnumerable<Assembly> Assemblies { get; }
    }
}