using Microsoft.AspNetCore.Mvc.Filters;

namespace PlayingWithActionFilters.Filters
{
    public class LogResultInfoAttribute : ResultFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            // ResultFilterAttribute non supporta la dependency injection, i servizi vanno ricavati dal contesto.
            var logger = context.HttpContext.RequestServices.GetRequiredService<ILogger<LogResultInfoAttribute>>();

            // Questo metodo viene eseguito prima che il risultato venga generato
            logger.LogInformation("ResultFilter - OnResultExecuting: Esecuzione prima della generazione del risultato");
            logger.LogInformation("Controller: {controller} - Action {action}", context.Controller, context.ActionDescriptor);
        }

        public override void OnResultExecuted(ResultExecutedContext context)
        {
            var logger = context.HttpContext.RequestServices.GetRequiredService<ILogger<LogResultInfoAttribute>>();

            // Questo metodo viene eseguito dopo che il risultato è stato generato
            logger.LogInformation("ResultFilter - OnResultExecuted: Esecuzione dopo la generazione del risultato");
            logger.LogInformation("Controller: {controller} - Action {action}", context.Controller, context.ActionDescriptor);
        }
    }

}
