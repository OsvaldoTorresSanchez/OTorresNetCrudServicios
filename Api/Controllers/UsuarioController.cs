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
        [HttpGet]
        [Route("api/usuario/getbyid/{IdUsuario}")]
        public IHttpActionResult GetById(int IdUsuario)
        {
            ML.Usuario materia = new ML.Usuario();
            ML.Result result = BL.Usuairo.GetById(IdUsuario);

            if (result.Correct)
            {
                return Ok(result);

            }
            else
            {
                return NotFound();
            }
        }


        [HttpPost]
        [Route("api/usuario/add")]
        public IHttpActionResult Add(ML.Usuario usuario)
        {
            ML.Usuario usuarios = new ML.Usuario();
            ML.Result result = BL.Usuairo.Add(usuario);

            if (result.Correct)
            {
                return Ok(result);

            }
            else
            {
                return NotFound();
            }
        }


        [HttpPut]
        [Route("api/usuario/update")]
        public IHttpActionResult Update(ML.Usuario usuario)
        {
            ML.Result result = BL.Usuairo.Add(usuario);

            if (result.Correct)
            {
                return Ok(result);

            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("api/usuario/delete/{IdUsuario}")]
        public IHttpActionResult Delete(int IdUsuario)
        {
            ML.Usuario usuario = new ML.Usuario();
            usuario.IdUsuario = IdUsuario;

            ML.Result result = BL.Usuairo.Delete(IdUsuario);

            if (result.Correct)
            {
                return Ok(result);

            }
            else
            {
                return NotFound();
            }
        }



        
        /// ////////////////////
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
        // POST: api/Usuario
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Usuario/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Usuario/5
        public void Deletes(int id)
        {
        }
    }
}
