namespace Level1.Internal
{
    using System;
    using System.ComponentModel.Composition.Hosting;
    using System.IO;

    static class ContainerHolder
    {
        private static object _locker = new object();
        private static CompositionContainer _container;

        static internal CompositionContainer GetOrCreate()
        {
            if (_container == null)
            {
                lock (_locker)
                {
                    if (_container == null)
                    {
                        _container = CreateContainer();
                    }
                }
            }

            return _container;
        }

        private static CompositionContainer CreateContainer()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin");
            var catalog = new DirectoryCatalog(path);
            var container = new CompositionContainer(catalog); // needs to be made thread-safe

            return container;
        }
    }
}
