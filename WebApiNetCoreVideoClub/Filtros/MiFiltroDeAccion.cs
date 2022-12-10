using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApiNetCoreVideoClub.Filtros
{
    public class MiFiltroDeAccion : IActionFilter
    {
        private readonly ILogger<MiFiltroDeAccion> _logger;

        public MiFiltroDeAccion(ILogger<MiFiltroDeAccion> logger)
        {
            this._logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            this._logger.LogInformation("Antes de ejecutar la acción");
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            this._logger.LogInformation("Despues de ejecutar la acción");
        }

    }
}
