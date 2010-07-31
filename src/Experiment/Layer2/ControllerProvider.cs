namespace Layer2
{
    using System.ComponentModel.Composition;
    using System.Web;

    [InheritedExport]
    public abstract class ControllerProvider
    {
        public abstract ControllerMeta Create(HttpContextBase context);
    }
}
