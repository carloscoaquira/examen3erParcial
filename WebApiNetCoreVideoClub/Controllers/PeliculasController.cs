using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApiNetCoreVideoClub.DTOs;
using WebApiNetCoreVideoClub.Entidades;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiNetCoreVideoClub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculasController : ControllerBase
    {

        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        public PeliculasController(ApplicationDbContext context,IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        // GET: api/<PeliculasController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PeliculasController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PeliculasController>
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] PeliculaCreacionDTO  peliculaCreacionDTO)
        {
            var pelicula = mapper.Map<Pelicula>(peliculaCreacionDTO);
            context.Add(pelicula);
            await context.SaveChangesAsync();
            return pelicula.Id;
        }

        // PUT api/<PeliculasController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PeliculasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
