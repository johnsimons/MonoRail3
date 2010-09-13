namespace Castle.MonoRail.Mef
{
    using System.ComponentModel.Composition.Hosting;

    public interface IMefContainerAccessor
    {
        CompositionContainer GetCurrentRequestContainer();
    }
}
