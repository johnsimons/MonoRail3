namespace Castle.MonoRail.Hosting.Mvc.Typed.Internal
{
    using System;
    using System.Collections.Generic;

    public abstract class ActionDescriptor
    {
        public ActionDescriptor()
        {
            this.Filters = new List<FilterDescriptor>();
        }

        public string Name { get; protected set; }
        public ICollection<FilterDescriptor> Filters { get; private set; }
        public Func<object, object[], object> Action { get; protected set; }
    }
}