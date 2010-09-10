namespace Castle.MonoRail.Mvc.Typed
{
    using System;
    using System.ComponentModel.Composition;

    // need to define buckets
    public interface IRequestSink
    {
        IRequestSink Next { get; set; }

        void Invoke(ActionInvocationContext invocationCtx);
    }

    public interface IRequestSinkConfig
    {
        int Order { get; }
    }

    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class RequestSinkConfigAttribute : ExportAttribute, IRequestSinkConfig
    {
        public RequestSinkConfigAttribute(int order) : base(typeof(IRequestSink))
        {
            this.Order = order;
        }

        public int Order { get; set; }
    }
}
