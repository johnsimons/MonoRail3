namespace Castle.MonoRail.Hosting.Mvc.Typed.Internal
{
    using System;
    using System.Collections.Generic;

    public class ControllerDescriptor
    {
        public ControllerDescriptor(Type controllerType, string name, string area)
        {
            this.ControllerType = controllerType;
            this.Name = name;
            this.Area = area;
            this.Actions = new List<ActionDescriptor>();
            this.Filters = new List<FilterDescriptor>();
        }

        public Type ControllerType { get; private set; }
        public string Name { get; private set; }
        public string Area { get; private set; }
        public ICollection<ActionDescriptor> Actions { get; private set; }
        public ICollection<FilterDescriptor> Filters { get; private set; }
    }
}
