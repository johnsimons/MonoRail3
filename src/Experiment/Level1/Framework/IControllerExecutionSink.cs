namespace Castle.MonoRail.Framework
{
    // do we need sentinels between buckets to enforce a sane status? 
    // i.e. confirm expectations/validate assumptions
    
    public interface IControllerExecutionSink
    {
        IControllerExecutionSink Next { get; set; }

        void Invoke(ControllerExecutionContext executionCtx);
    }
}
