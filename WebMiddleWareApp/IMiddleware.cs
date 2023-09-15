namespace WebMiddleWareApp
{
    public interface IMiddleware
    {
        Task Invoke(HttpContext context);
    }
}