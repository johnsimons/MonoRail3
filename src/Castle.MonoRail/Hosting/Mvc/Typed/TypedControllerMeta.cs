namespace Castle.MonoRail.Hosting.Mvc.Typed
{
    using Internal;
    using Primitives;

    public class TypedControllerMeta : ControllerMeta
    {
        public ControllerDescriptor ControllerDescriptor { get; private set; }

        public TypedControllerMeta(object controller, ControllerDescriptor controllerDescriptor) : base(controller)
        {
            ControllerDescriptor = controllerDescriptor;
        }
    }
}
