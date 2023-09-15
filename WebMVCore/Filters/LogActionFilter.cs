using Microsoft.AspNetCore.Mvc.Filters;

namespace WebMVCore.Filters
{
    public class LogActionFilter : IActionFilter
    {
        string _action;
        private readonly ILogger<LogActionFilter> _logger;
        public LogActionFilter(ILogger<LogActionFilter> logger)
        {
            _logger = logger;
        }


        public void OnActionExecuted(ActionExecutedContext context)
        {
            _action = context.ActionDescriptor.DisplayName;
            _logger.Log(LogLevel.Information, $"L'action {_action} est executée");

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _action = context.ActionDescriptor.DisplayName;
            _logger.Log(LogLevel.Information, $"L'action {_action} est" +
                $" encour d'exécution");

        }
    }
}
