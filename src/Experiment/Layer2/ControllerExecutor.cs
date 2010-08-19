﻿namespace Layer2
{
    using System;
    using System.Collections.Generic;
    using System.Web;

    public abstract class ControllerExecutor
    {
		public IEnumerable<IRequestSink> RequestSink { get; set; }

        public abstract void Process(HttpContextBase context);
    }
}
