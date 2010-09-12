namespace Castle.MonoRail.Hosting.Internal
{
    using System;
    using System.ComponentModel.Composition;
    using System.ComponentModel.Composition.Hosting;
    using System.ComponentModel.Composition.Primitives;
    using System.Diagnostics.Contracts;
    using System.IO;
    using System.Web;

    // for the lack of a better name
    static class ContainerManager
    {
        private static object _locker = new object();
        private static ComposablePartCatalog _catalog;
        private static ComposablePartCatalog _requestCatalog;
        private static CompositionContainer _container;

        // appdomain wide side effect (statics)
        static internal CompositionContainer GetOrCreateParentContainer()
        {
            Contract.Ensures(_container != null);
            Contract.EndContractBlock();

            if (_container == null)
            {
                lock (_locker)
                {
                    if (_container == null)
                    {
                        SubscribeToEndRequest();
                        _container = CreateContainer();
                    }
                }
            }

            return _container;
        }

        private static void SubscribeToEndRequest()
        {
            HttpContext.Current.ApplicationInstance.EndRequest += OnEndRequestDisposeContainer;
        }

        const string RequestContainerKey = "infra.mef.requestcontainer";

        public static CompositionContainer GetRequestContainer()
        {
            var ctx = HttpContext.Current;
            var container = (CompositionContainer)ctx.Items[RequestContainerKey];

            if (container == null)
            {
                var parent = GetOrCreateParentContainer();
                container = new CompositionContainer(_requestCatalog, parent);
                ctx.Items[RequestContainerKey] = container;
            }

            return container;
        }

        private static void OnEndRequestDisposeContainer(object sender, EventArgs e)
        {
            var ctx = HttpContext.Current;
            var container = (CompositionContainer)ctx.Items[RequestContainerKey];
            
            if (container != null)
            {
                container.Dispose();
                ctx.Items[RequestContainerKey] = null;
            }
        }

        // Extension method to simplify filtering expression
        public static bool IsShared(this ComposablePartDefinition part)
        {
            var m = part.Metadata;
            object value;
            if (m.TryGetValue(CompositionConstants.PartCreationPolicyMetadataName, out value))
            {
                return ((CreationPolicy)value) == CreationPolicy.Shared;
            }
            return false;
        }

        // catalog creation needs to be configurable
        private static CompositionContainer CreateContainer()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin");
            var catalog = new DirectoryCatalog(path);

            var partitioned = new PartitionedCatalog(catalog, p => !p.IsShared());
            _requestCatalog = partitioned;
            _catalog = partitioned.Complement;

            var container = new CompositionContainer(_catalog); // needs to be made thread-safe

            return container;
        }
    }
}
