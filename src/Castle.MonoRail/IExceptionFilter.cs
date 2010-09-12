namespace Castle.MonoRail
{
    public class ExceptionFilterContext
    {
    }

    public interface IExceptionFilter
    {
        void OnException(ExceptionFilterContext context);
    }
}
