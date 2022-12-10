using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiNetCoreVideoClub.DTOs;
using WebApiNetCoreVideoClub.Entidades;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiNetCoreVideoClub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CinesController : ControllerBase
    {

        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        public CinesController(ApplicationDbContext context,IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        // GET: api/<CinesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CinesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CinesController>
        [HttpPost]
        public ActionResult Post([FromBody] CineCreacionDTO cineCreacionDTO)
        {
            var cine = this.mapper.Map<Cine>(cineCreacionDTO);
            this.context.Cines.Add(cine);
            this.context.SaveChanges();
            return NoContent();
        }

        // PUT api/<CinesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CinesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
