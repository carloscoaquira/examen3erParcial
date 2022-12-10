using Microsoft.EntityFrameworkCore;

namespace WebApiNetCoreVideoClub.Utilidades
{
    public static class HttpContextExtensions
    {
        public async static Task InsertarParametrosPaginacionEnCabecera<T>(
            this HttpContext httpContex,IQueryable<T> queryable)
        {
            if(httpContex==null)
            {
                throw new ArgumentNullException(nameof(httpContex));
            }

            double cantidad=await queryable.CountAsync();
            httpContex.Response.Headers.Add("cantidadTotalRegistros", cantidad.ToString());

        }
            
    }
}
