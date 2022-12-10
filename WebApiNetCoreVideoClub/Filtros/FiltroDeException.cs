using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApiNetCoreVideoClub.Filtros
{
    public class FiltroDeException:ExceptionFilterAttribute
    {
        private readonly ILogger<FiltroDeException> _logger;

        public FiltroDeException(ILogger<FiltroDeException> logger)
        {
            this._logger = logger;
        }

        public override void OnException(ExceptionContext context)
        {
            this._logger.LogError(context.Exception, context.Exception.Message);  
            base.OnException(context);
        }
    }
}
