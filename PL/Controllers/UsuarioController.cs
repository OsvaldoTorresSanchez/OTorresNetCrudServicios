using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAll()
        {
            ML.Usuario usuario = new ML.Usuario();
            usuario.Usuarios = new List<object>();

            ML.Result result = BL.Usuairo.GetAll();

            if (result != null)
            {

                usuario.Usuarios = result.Objects;
            }
            else
            {
                ViewBag.Message = result.ErrorMessage;

            }

            return View(usuario);

        }


        [HttpGet]
        public ActionResult Formulario(int? IdUsuario)
        {
            ML.Usuario usuario = new ML.Usuario();
            usuario.Usuarios = new List<object>();

            if (IdUsuario > 0)
            {
                ML.Result result = BL.Usuairo.GetById((int)IdUsuario);

                if (result.Correct)
                {
                    usuario = (ML.Usuario)result.Object;
                }
            }
            else
            {
                return View(usuario);
            }

            return View(usuario);
        }

        [HttpPost]
        public ActionResult Formulario(ML.Usuario usuario)
        {
            if(usuario.IdUsuario == 0)
            {
                ML.Result result = BL.Usuairo.Add(usuario);
                if(result.Correct)
                {
                    ViewBag.Message = "Se ingreso corectamente el usuario "+ usuario.Nombre;

                }
                else
                {
                    ViewBag.Message = "No se ingreso correctamente el usuario" + usuario.Nombre;
                    
                }
            }
            else
            {
                ML.Result result = BL.Usuairo.Update(usuario);

                if(result.Correct)
                {
                    ViewBag.Message = "Se actualizo correctamente " + usuario.Nombre;

                }
                else
                {
                    ViewBag.Message = "No se  actualizo correctamente " +  usuario.Nombre;

                }


            }
            return PartialView("Modal");
        }


        // API
        public ActionResult GetAllAPI()
        {
            ML.Usuario usuario = new ML.Usuario();
            usuario.Usuarios = new List<object>();

           
            using (var client = new HttpClient())
            {
                //client.BaseAddress = new Uri(URLApi);
                client.BaseAddress = new Uri("http://localhost:55804/api/usuario/getall");

                var responseTask = client.GetAsync("getall");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ML.Result>();
                    readTask.Wait();

                    foreach (var resultItem in readTask.Result.Objects)
                    {
                        ML.Usuario resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Usuario>(resultItem.ToString());
                        usuario.Usuarios.Add(resultItemList);
                    }
                }
            }
            return View(usuario);
        }

        // WCF
        public ActionResult GetAllWCF()
        {
            ML.Usuario usuario = new ML.Usuario();
            usuario.Usuarios = new List<object>();

            ServiceUsuario.UsuarioClient empleadoClient = new ServiceUsuario.UsuarioClient();
            var result = empleadoClient.GetAll();

            if (result != null)
            {

                usuario.Usuarios = result.Objects;
            }
            else
            {
                ViewBag.Message = result.ErrorMessage;

            }

            return View(usuario);

        }

    }
}