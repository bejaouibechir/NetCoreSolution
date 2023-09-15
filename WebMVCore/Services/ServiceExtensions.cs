namespace WebMVCore.Services
{
    static public class ServiceExtensions
    {
        static public void AddLogService(this IServiceCollection services) {    
           services.AddTransient(typeof(IService),typeof(LogService));
        }
    }
}
