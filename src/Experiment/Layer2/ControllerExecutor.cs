﻿namespace Layer2
{
    using System;
    using System.Web;

    public abstract class ControllerExecutor
    {
        public abstract void Process(HttpContextBase context);
    }
}
