namespace Castle.MonoRail
{
    using System.Collections.Generic;
    using Hosting.Mvc;

    public interface IMonoRailServices
    {
        CompositeViewEngine ViewEngines { get; }
    }
}
