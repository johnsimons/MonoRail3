﻿namespace Castle.MonoRail.Hosting.Mvc.Typed.Internal
{
    using System;

    public interface IWebFormFactory
    {
        object CreateInstanceFromVirtualPath(string path, Type baseType);
    }
}
