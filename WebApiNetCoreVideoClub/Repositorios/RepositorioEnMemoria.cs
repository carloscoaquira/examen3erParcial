using WebApiNetCoreVideoClub.Entidades;

namespace WebApiNetCoreVideoClub.Repositorios
{
    public class RepositorioEnMemoria:IRepositorio
    {
        private List<Genero> _generos;
        private Guid guid;
        public RepositorioEnMemoria()
        {
            _generos = new List<Genero>()
            {
                new Genero(){Id=1,Nombre="Comedia"},
                new Genero(){Id=2,Nombre="Accion"},
                new Genero(){Id=2,Nombre="Drama"}
            };

            this.guid = Guid.NewGuid();
        }

        public List<Genero> ObtenerTodosLosGeneros()
        {
            return this._generos;
        }

        public Guid ObtenerGuid()
        {
            return this.guid;
        }

    }
}
