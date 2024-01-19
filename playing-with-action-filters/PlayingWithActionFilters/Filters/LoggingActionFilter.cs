using Microsoft.AspNetCore.Mvc.Filters;

namespace PlayingWithActionFilters.Filters
{
    public class LoggingActionFilter : IActionFilter
    {
        private readonly ILogger<LoggingActionFilter> _logger;

        public LoggingActionFilter(ILogger<LoggingActionFilter> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Questo metodo viene eseguito prima che il risultato venga generato
            this._logger.LogInformation("Esecuzione prima di chiamare l'action");
            this._logger.LogInformation("Path: {action}", context.ActionDescriptor.DisplayName);
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Questo metodo viene eseguito prima che il risultato venga generato
            this._logger.LogInformation("Esecuzione dopo l'action");
            this._logger.LogInformation("Path: {action}", context.ActionDescriptor.DisplayName);
        }
    }
}
