namespace Level1
{
    using System.Web;

    public interface IComposableHandler
    {
        void ProcessRequest(HttpContextBase context);
    }
}
