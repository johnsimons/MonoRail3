namespace Layer2.Typed
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Reflection;
    using System.Linq;
    using System.Web;
    using System.Web.Compilation;
    using System.Web.Routing;

    public class ReflectionBasedControllerProvider : ControllerProvider
    {
        private readonly IAssembliesSource _source;
        private List<Tuple<string,Type>> _validTypes;

        [ImportingConstructor]
        public ReflectionBasedControllerProvider(IAssembliesSource source)
        {
            _source = source;
        }

        public override ControllerMeta Create(RouteData data, HttpContextBase context)
        {
            if (_validTypes == null)
            {
                _validTypes = new List<Tuple<string,Type>>(
                    _source.Assemblies.SelectMany(a => a.GetTypes()).
                        Where(t => t.Name.EndsWith("Controller") && !t.IsAbstract).
                        Select(t=> new Tuple<string,Type>(
                            t.Name.Substring(0, t.Name.Length - "Controller".Length).ToLowerInvariant(), t)));
            }

            var controllerName = data.GetRequiredString("controller");
            var controllerType = _validTypes.Where(t => string.CompareOrdinal(t.Item1, controllerName) == 0).Select(t => t.Item2).FirstOrDefault();

            if (controllerType == null)
                return null;

            var controller = Activator.CreateInstance(controllerType);
            var meta = new ControllerMeta(controller);

            meta.Metadata["controller.from"] = "simpletype";

            return meta;
        }
    }

    public interface IAssembliesSource
    {
        IEnumerable<Assembly> Assemblies { get; }
    }

	//[Export(typeof(IAssembliesSource))]
	//public class BuildManagerAssembliesSource : IAssembliesSource
	//{
	//    public IEnumerable<Assembly> Assemblies
	//    {
	//        get { return BuildManager.CodeAssemblies.Cast<Assembly>(); }
	//    }
	//}

	[Export(typeof(IAssembliesSource))]
	public class AppDomainAssembliesSource : IAssembliesSource
	{
		public IEnumerable<Assembly> Assemblies
		{
			get { return AppDomain.CurrentDomain.GetAssemblies(); }
		}
	}
}
