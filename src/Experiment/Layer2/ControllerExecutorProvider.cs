namespace Layer2
{
    using System.ComponentModel.Composition;
    using System.Web;

    [InheritedExport]
    public abstract class ControllerExecutorProvider
    {
        public abstract ControllerExecutor CreateExecutor(ControllerMeta meta, HttpContextBase context);
    }
}
