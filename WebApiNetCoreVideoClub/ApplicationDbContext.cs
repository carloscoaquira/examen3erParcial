using Microsoft.EntityFrameworkCore;
using WebApiNetCoreVideoClub.Entidades;

namespace WebApiNetCoreVideoClub
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PeliculasGeneros>()
                .HasKey(x => new { x.PeliculaId, x.GeneroId });

            base.OnModelCreating(modelBuilder);
        }



        public DbSet<Genero> Generos { get; set; }
        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<PeliculasGeneros> PeliculasGeneros { get; set; }

        public DbSet<Cine> Cines { get; set; }


    }
}
