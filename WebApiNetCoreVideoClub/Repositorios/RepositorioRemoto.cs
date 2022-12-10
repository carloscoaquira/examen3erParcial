using WebApiNetCoreVideoClub.Entidades;

namespace WebApiNetCoreVideoClub.Repositorios
{
    //public class RepositorioRemoto:IRepositorio
    public class RepositorioRemoto 
    {
        private List<Genero> _generos;
        public RepositorioRemoto()
        {
            _generos = new List<Genero>()
            {
                new Genero(){Id=1,Nombre="Comedia remoto"},
                new Genero(){Id=2,Nombre="Accion remoto"}
            };
        }

        public List<Genero> ObtenerTodosLosGeneros()
        {
            return this._generos;
        }


    }
}
