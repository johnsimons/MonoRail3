﻿namespace Layer2
{
    using System.ComponentModel.Composition;
    using System.Web;
    using System.Web.Routing;

    [InheritedExport]
    public abstract class ControllerExecutorProvider
    {
        public abstract ControllerExecutor CreateExecutor(ControllerMeta meta, RouteData data, HttpContextBase context);
    }
}
