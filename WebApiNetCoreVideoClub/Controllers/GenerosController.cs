using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiNetCoreVideoClub.DTOs;
using WebApiNetCoreVideoClub.Entidades;
using WebApiNetCoreVideoClub.Filtros;
using WebApiNetCoreVideoClub.Repositorios;
using WebApiNetCoreVideoClub.Utilidades;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiNetCoreVideoClub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class GenerosController : ControllerBase
    {
        //private RepositorioEnMemoria repositorio = new RepositorioEnMemoria();
        private readonly ILogger<GenerosController> logger;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        public GenerosController(ApplicationDbContext context, 
            ILogger<GenerosController> logger,
            IMapper mapper)
        {
            this.logger = logger;
            this.context = context;
            this.mapper = mapper;
        }

        // GET: api/<GenerosController>
        [HttpGet]
        [ServiceFilter(typeof(MiFiltroDeAccion))]
        /*
        public List<Genero> Get()
        {
            this.logger.LogInformation("Mensaje LogInformation");
            return this.context.Generos.ToList();
        }
        */
        /*
        public List<GeneroDTO> Get()
        {//mapeo manual datos de la tabla a un DTO
            var generos= this.context.Generos.ToList();
            var resultado=new List<GeneroDTO>();
            foreach(var item in generos)
            {
                resultado.Add(new GeneroDTO() { Id = item.Id, Nombre = item.Nombre });
            }
            return resultado;
        }
        */
        public  async Task<ActionResult<List<GeneroDTO>>> Get([FromQuery] PaginacionDTO paginacionDTO)
        {
            var queryable = context.Generos.AsQueryable();
            await HttpContext.InsertarParametrosPaginacionEnCabecera(queryable);
            var generos = await queryable.OrderBy(x => x.Nombre).Paginar(paginacionDTO).ToListAsync(); 
            return this.mapper.Map<List<GeneroDTO>>(generos);
        }


        // GET api/<GenerosController>/5
        [HttpGet("{id}")]               
        public async Task <ActionResult<GeneroDTO>> Get(int id)
        {
            var genero=await context.Generos.FirstOrDefaultAsync(x => x.Id == id);
            if(genero == null)
            {
                return NotFound();
            }
            return this.mapper.Map<GeneroDTO>(genero);

        }

        // POST api/<GenerosController>
        [HttpPost]
        public ActionResult Post([FromBody] GeneroCreacionDTO generoCreacionDTO)
        {
            var genero = this.mapper.Map<Genero>(generoCreacionDTO);
            this.context.Generos.Add(genero);
            this.context.SaveChanges();
            return NoContent();
        }

        // PUT api/<GenerosController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] GeneroCreacionDTO generoCreacionDTO)
        {
            var genero = await context.Generos.FirstOrDefaultAsync(x => x.Id == id);
            if (genero == null)
            {
                return NotFound();
            }
            genero = mapper.Map(generoCreacionDTO, genero);
            await context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE api/<GenerosController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe= await context.Generos.AnyAsync(x => x.Id == id);
            if(!existe)
            {
                return NotFound();
            }
            context.Remove(new Genero() { Id = id });
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
