using Microsoft.AspNetCore.Mvc.Filters;

namespace WebMVCore.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<ExceptionFilter> _logger;

        public ExceptionFilter(ILogger<ExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;  
            if (exception != null)
            {
                _logger.Log(LogLevel.Error, exception.StackTrace);
            }
            context.ExceptionHandled = true;    
        }
    }
}
