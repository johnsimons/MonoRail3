namespace Layer1.Internal
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition.Primitives;
    using System.Linq;
    using System.Threading;

    class PartitionedCatalog : ComposablePartCatalog
    {
        private readonly ComposablePartCatalog _source;
        private readonly Predicate<ComposablePartDefinition> _filter;
        private readonly object _locker = new object();
        private IQueryable<ComposablePartDefinition> _parts;
        private ComposablePartCatalog _complement;

        public PartitionedCatalog(ComposablePartCatalog source, Predicate<ComposablePartDefinition> filter)
        {
            _source = source;
            _filter = filter;
        }

        public override IQueryable<ComposablePartDefinition> Parts
        {
            get
            {
                if (_parts == null)
                {
                    lock (_locker)
                    {
                        if (_parts == null)
                        {
                            _parts = FilterCatalog();
                            Thread.MemoryBarrier();
                        }
                    }
                }

                return _parts;
            }
        }

        public ComposablePartCatalog Complement 
        { 
            get
            {
                if (_complement == null)
                {
                    var dummy = this.Parts; // ensure filtering happened
                }
                return _complement;
            }
        }

        private IQueryable<ComposablePartDefinition> FilterCatalog()
        {
            var trueSet = new List<ComposablePartDefinition>();
            var falseSet = new List<ComposablePartDefinition>();

            foreach(var part in _source.Parts)
            {
                if (_filter(part))
                    trueSet.Add(part);
                else
                    falseSet.Add(part);
            }

            _complement = new BasicCatalog(falseSet.AsQueryable());

            return trueSet.AsQueryable();
        }

        class BasicCatalog : ComposablePartCatalog
        {
            private readonly IQueryable<ComposablePartDefinition> _parts;

            public BasicCatalog(IQueryable<ComposablePartDefinition> parts)
            {
                _parts = parts;
            }

            public override IQueryable<ComposablePartDefinition> Parts
            {
                get { return _parts; }
            }
        }
    }
}
