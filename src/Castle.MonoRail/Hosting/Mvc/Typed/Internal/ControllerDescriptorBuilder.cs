namespace Castle.MonoRail.Hosting.Mvc.Typed.Internal
{
    using System;
    using System.ComponentModel.Composition;
    using System.Diagnostics.Contracts;
    using System.Reflection;

    [Export]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class ControllerDescriptorBuilder
    {
        // needs caching (per instance)
        public ControllerDescriptor Build(Type controllerType)
        {
            Contract.Requires(controllerType != null);
            Contract.EndContractBlock();

            string name = controllerType.Name;
            name = name.Substring(0, name.Length - "Controller".Length).ToLowerInvariant();

            var controllerDesc = new ControllerDescriptor(controllerType, name, area: string.Empty);

            foreach (var method in controllerType.GetMethods(BindingFlags.Instance | BindingFlags.Public))
            {
                var action = BuildActionDescriptor(method);
                
                if (action != null)
                    controllerDesc.Actions.Add(action);
            }

            return controllerDesc;
        }

        private ActionDescriptor BuildActionDescriptor(MethodInfo method)
        {
            Contract.Requires(method != null);
            Contract.EndContractBlock();

            if (method.IsSpecialName ||
                method.IsGenericMethodDefinition || method.IsStatic ||
                method.DeclaringType == typeof(object))
            {
                return null;
            }

            return new MethodInfoActionDescriptor(method);
        }
    }
}