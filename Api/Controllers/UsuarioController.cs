using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.Controllers
{
    public class UsuarioController : ApiController
    {
        // GET: api/Usuario
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Usuario/5
        public string Get(int id)
        {
            return "value";
        }

        [HttpGet]
        [Route("api/usuario/getall")]
        public IHttpActionResult GetAll()
        {
            // ML.Materia materia = new ML.Materia();
            ML.Result result = BL.Usuairo.GetAll();

            if (result.Correct)
            {
                return Ok(result);

            }
            else
            {
                return NotFound();
            }
        }

        // POST: api/Usuario
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Usuario/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Usuario/5
        public void Delete(int id)
        {
        }
    }
}
