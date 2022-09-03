using Microsoft.AspNetCore.Mvc;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiNetCoreVideoClub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneroController : ControllerBase
    {
        // GET: api/<GeneroController>
        [HttpGet]
        [Route("listadoCompleto")]
        public respuestaGeneroGetEstandar listar()
        {

            respuestaGeneroGetEstandar objRespuesta = new respuestaGeneroGetEstandar();
            objRespuesta.codigo = 1;
            objRespuesta.mensaje = "ERROR";
            
            List<respuestaGeneroGet> lista = new List<respuestaGeneroGet>();

            try
            {
                clsGenero objGenero = new clsGenero();
                DataTable dt = objGenero.ListadoCompleto();
                foreach (DataRow row in dt.Rows)
                {
                    respuestaGeneroGet obj = new respuestaGeneroGet();
                    obj.codigo = Convert.ToInt32(row["idgenero"]);
                    obj.nombre = Convert.ToString(row["nombre"]);
                    obj.descripcion = Convert.ToString(row["descripcion"]);

                    objRespuesta.lista.Add(obj);

                }

                objRespuesta.codigo = 0;
                objRespuesta.mensaje = "PROCESO CORRECTO";

            }
            catch (Exception ex)
            {
                objRespuesta.mensaje = ex.Message;
            }
            
            return objRespuesta;
        }

        // GET api/<GeneroController>/5
        [HttpGet]
        [Route("busquedaPorId")]
        public respuestaGeneroGetRegistro buscarPorId(int id)
        {
            respuestaGeneroGetRegistro objRespuesta = new respuestaGeneroGetRegistro();
            objRespuesta.codigo = 1;
            objRespuesta.mensaje = "ERROR";

            try
            {
                clsGenero objGenero = new clsGenero();
                objGenero.idgenero = id;
                if (objGenero.BuscarPorId())
                {
                    objRespuesta.codigo = 0;
                    objRespuesta.mensaje = "TRANSACCION CORRECTA";
                    objRespuesta.data.codigo = objGenero.idgenero;
                    objRespuesta.data.nombre = objGenero.nombre;
                    objRespuesta.data.descripcion = objGenero.descripcion;

                }

            }
            catch (Exception ex)
            {
                objRespuesta.mensaje = ex.Message;
            }

            return objRespuesta;
        }

        [HttpGet]
        [Route("listadoPorNombre")]
        public string listarPorNombre(String nombre)
        {
            return "value get 3";
        }


        // POST api/<GeneroController>
        [HttpPost]
        [Route("registro")]
        public respuestaEstandar  registrarGenero([FromBody] parametrosGeneroPost objParametros)
        {
            respuestaEstandar objRespuesta = new respuestaEstandar();
            objRespuesta.codigo = 1;
            objRespuesta.mensaje = "PROCESO FALLIDO";

            try
            {
                clsGenero objGenero = new clsGenero();
                objGenero.nombre = objParametros.nombre;
                objGenero.descripcion = objParametros.descripcion;
                if (objGenero.Insertar())
                {
                    objRespuesta.codigo = 0;
                    objRespuesta.mensaje = "PROCESO CORRECTO";
                }
            }
            catch (Exception ex)
            {
                objRespuesta.mensaje = ex.Message; 
            }            

            return objRespuesta;

        }

        // PUT api/<GeneroController>/5
        [HttpPut]
        [Route("actualizacion")]
        public respuestaEstandar actualizar(int id, [FromBody] respuestaGeneroGet objParametro)
        {
            respuestaEstandar objRespuesta = new respuestaEstandar();
            objRespuesta.codigo = 1;
            objRespuesta.mensaje = "PROCESO FALLIDO";
            try
            {
                clsGenero objGenero = new clsGenero();

                objGenero.idgenero = objParametro.codigo;
                objGenero.nombre = objParametro.nombre;
                objGenero.descripcion = objParametro.descripcion;

                if (objGenero.Actualizar())
                {
                    objRespuesta.codigo = 0;
                    objRespuesta.mensaje = "PROCESO CORRECTO";
                }
            }
            catch (Exception ex)
            {
                objRespuesta.mensaje = ex.Message;
            }

            return objRespuesta;

        }

        // DELETE api/<GeneroController>/5
        [HttpDelete]
        [Route("baja")]
        public respuestaEstandar Eliminar(int id)
        {
            respuestaEstandar objRespuesta = new respuestaEstandar();
            objRespuesta.codigo = 1;
            objRespuesta.mensaje = "PROCESO FALLIDO";
            try
            {
                clsGenero objGenero = new clsGenero();

                objGenero.idgenero = id;

                if (objGenero.Eliminar())
                {
                    objRespuesta.codigo = 0;
                    objRespuesta.mensaje = "PROCESO CORRECTO";
                }
            }
            catch (Exception ex)
            {
                objRespuesta.mensaje = ex.Message;
            }

            return objRespuesta;
        }
    }
}
