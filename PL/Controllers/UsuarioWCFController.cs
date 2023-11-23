using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class UsuarioWCFController : Controller
    {
        // GET: UsuarioWCF
        public ActionResult Index()
        {
            return View();
        }

        // WCF
        public ActionResult GetAllWCF()
        {
            ML.Usuario usuario = new ML.Usuario();
            usuario.Usuarios = new List<object>();

            ServiceUsuario.UsuarioClient UsuarioClient = new ServiceUsuario.UsuarioClient();
            var result = UsuarioClient.GetAll();

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
        public ActionResult FormularioWCF(int? IdUsuario)
        {
            ML.Usuario usuario = new ML.Usuario();
            usuario.Usuarios = new List<object>();

            if (IdUsuario == null) // Add
            {
                return View(usuario);
            }
            else //Update
            {
                ServiceUsuario.UsuarioClient UsuarioClient = new ServiceUsuario.UsuarioClient();
                var result = UsuarioClient.GetById((int)IdUsuario);

                if (result.Correct)
                {
                    usuario = (ML.Usuario)result.Object;
                    //ViewBag.Message = "Se ha actualizado correctamente el alumno";
                }

                return View(usuario); // Vacio
            }
        }
        [HttpPost]
        public ActionResult FormularioWCF(ML.Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                if (usuario.IdUsuario == 0)
                {
                    ServiceUsuario.UsuarioClient UsuarioClient = new ServiceUsuario.UsuarioClient();
                    var result = UsuarioClient.Add(usuario);

                    if (result.Correct)
                    {
                        ViewBag.Message = "Se ha ingresado correctamente el alumno";

                    }
                    else
                    {
                        ViewBag.Message = "no se ingresado correctemnte el alumno , Error: " + result.ErrorMessage;
                    }
                }
                else
                {
                    ServiceUsuario.UsuarioClient UsuarioClient = new ServiceUsuario.UsuarioClient();
                    var result = UsuarioClient.Update(usuario);
                    if (result.Correct)
                    {

                        ViewBag.Message = "Se ha actualizado correctamente el alumno";

                    }
                    else
                    {
                        ViewBag.Message = "no se actualizado correctemnte el alumno , Error: " + result.ErrorMessage;
                    }
                }
                return PartialView("Modal");
            }
            else
            {
                return View(usuario);
            }
        }

        public ActionResult DeleteWCF(ML.Usuario usuario)
        {
            ServiceUsuario.UsuarioClient UsuarioClient = new ServiceUsuario.UsuarioClient();
            var result = UsuarioClient.Delete(usuario);

            if (result.Correct)
            {
                ViewBag.Message = "Se ha eliminado correctamente el alumno";

            }
            else
            {
                ViewBag.Message = "no se puede eliminar correctemnte el alumno , Error: " + result.ErrorMessage;
            }

            return PartialView("Modal");
        }
    }
}