using WebApiNetCoreVideoClub.Entidades;

namespace WebApiNetCoreVideoClub.Repositorios
{
    public interface IRepositorio
    {
        List<Genero> ObtenerTodosLosGeneros();
        Guid ObtenerGuid();
    }
}
