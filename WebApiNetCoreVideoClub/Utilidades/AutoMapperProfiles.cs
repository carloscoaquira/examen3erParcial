using AutoMapper;
using WebApiNetCoreVideoClub.DTOs;
using WebApiNetCoreVideoClub.Entidades;

namespace WebApiNetCoreVideoClub.Utilidades
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Genero, GeneroDTO>().ReverseMap();
            CreateMap<GeneroCreacionDTO, Genero>();

            CreateMap<Cine, CineDTO>().ReverseMap();
            CreateMap<CineCreacionDTO, Cine>();

            CreateMap<PeliculaCreacionDTO, Pelicula>()
            .ForMember(x => x.PeliculasGeneros, opciones =>
            opciones.MapFrom(MapearPeliculasGeneros));
        }

        private List<PeliculasGeneros> MapearPeliculasGeneros(PeliculaCreacionDTO peliculaCreacionDTO,
            Pelicula pelicula            
            )
        {
            var resultado=new List<PeliculasGeneros>();

            if (peliculaCreacionDTO.GenerosIds == null) { return resultado; }

            foreach (var id in peliculaCreacionDTO.GenerosIds)
            {
                resultado.Add(new PeliculasGeneros() { GeneroId = id });
            }
            return resultado;
        }

    }
}
