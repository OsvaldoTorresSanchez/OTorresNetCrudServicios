using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class BusquedaController : Controller
    {
        // GET: Busqueda
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

        [HttpPost]
        public ActionResult GetAll(ML.Usuario usuario)
        {
            ML.Result result = BL.Usuairo.GetAllEFView(usuario);
            usuario.Usuarios = new List<object>();

            if (result.Correct)
            {
                // empleado.Empleados.ToList();
                usuario.Usuarios = result.Objects;
            }
            else
            {
                ViewBag.Message = result.ErrorMessage; //Mandar datos a Controller hacia la vista
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
            if (usuario.IdUsuario == 0)
            {
                ML.Result result = BL.Usuairo.Add(usuario);
                if (result.Correct)
                {
                    ViewBag.Message = "Se ingreso corectamente el usuario " + usuario.Nombre;

                }
                else
                {
                    ViewBag.Message = "No se ingreso correctamente el usuario" + usuario.Nombre;

                }
            }
            else
            {
                ML.Result result = BL.Usuairo.Update(usuario);

                if (result.Correct)
                {
                    ViewBag.Message = "Se actualizo correctamente " + usuario.Nombre;

                }
                else
                {
                    ViewBag.Message = "No se  actualizo correctamente " + usuario.Nombre;

                }


            }
            return PartialView("Modal");
        }

        public ActionResult Delete(int IdUsuario)
        {
            ML.Result result = BL.Usuairo.Delete(IdUsuario);

            if (result.Correct)
            {
                ViewBag.Message = "Se elimino correctamente el usuario ";
            }
            else
            {
                ViewBag.Message = "No se elimino el registro " + result.ErrorMessage;
            }

            return PartialView("Modal");
        }

    }
}