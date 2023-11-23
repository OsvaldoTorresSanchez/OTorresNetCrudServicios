using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class UsuarioAPIController : Controller
    {
        // GET: UsuarioAPI
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetAllAPI()
        {
            ML.Usuario usuario = new ML.Usuario();
            usuario.Usuarios = new List<object>();


            using (var client = new HttpClient())
            {
                //client.BaseAddress = new Uri(URLApi);
                client.BaseAddress = new Uri("http://localhost:55804/api/usuario/");

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

        [HttpGet]
        public ActionResult FormularioAPI(int? IdUsuario)
        {
            ML.Usuario materia = new ML.Usuario();


            if (IdUsuario == null) // Add
            {
                return View(materia);
            }
            else //Update
            {
                ML.Result result = new ML.Result();

                try
                {
                    using (var client = new HttpClient())
                    {
                        //client.BaseAddress = new Uri(URLApi);
                        client.BaseAddress = new Uri("http://localhost:55804/api/usuario/");
                        var responseTask = client.GetAsync("getbyid/" + IdUsuario);
                        responseTask.Wait();
                        var resultAPI = responseTask.Result;
                        if (resultAPI.IsSuccessStatusCode)
                        {
                            var readTask = resultAPI.Content.ReadAsAsync<ML.Result>();
                            readTask.Wait();
                            ML.Usuario resultItemList = new ML.Usuario();
                            resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Usuario>(readTask.Result.Object.ToString());
                            result.Object = resultItemList;

                            materia = (ML.Usuario)result.Object;
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No existen registros en la tabla materia";

                        }

                    }

                }

                catch (Exception ex)
                {
                    result.Correct = false;
                    result.ErrorMessage = ex.Message;

                }
                return View(materia); // Vacio
            }
        }

        [HttpPost]
        public ActionResult FormularioAPI(ML.Usuario usuario)
        {

            if (usuario.IdUsuario == 0) // ADD
            {
                using (var client = new HttpClient())
                {
                    //client.BaseAddress = new Uri(URLApi);
                    client.BaseAddress = new Uri("http://localhost:55804/api/usuario/");

                    var postTask = client.PostAsJsonAsync<ML.Usuario>("Add", usuario);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        ViewBag.Message = "Se ha ingresado correctamente el usuario" + usuario.Nombre;
                    }
                    else
                    {
                        ViewBag.Message = "no se ingresado correctemnte el usuario  , Error: " + result.StatusCode;
                    }
                }
            }
            else // UPDATE
            {

                using (var client = new HttpClient())
                {
                    //client.BaseAddress = new Uri(URLApi);
                    client.BaseAddress = new Uri("http://localhost:55804/api/usuario/");


                    //HTTP POST
                    var postTask = client.PutAsJsonAsync<ML.Usuario>("update", usuario);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        ViewBag.Message = "Se ha actualizado correctamente el usuario";
                    }
                    else
                    {
                        ViewBag.Message = "no se actualizado correctemnte el usuario , Error: " + result.StatusCode;
                    }
                }
            }

            return PartialView("Modal");
        }

        public ActionResult DeleteAPI(ML.Usuario usuario)
        {

            int id = usuario.IdUsuario;
            using (var client = new HttpClient())
            {
                //client.BaseAddress = new Uri(URLApi);
                client.BaseAddress = new Uri("http://localhost:55804/api/usuario/");

                //HTTP POST
                var postTask = client.DeleteAsync("delete/" + id);
                postTask.Wait();

                var result = postTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    ViewBag.Message = "Se ha eliminado correctamente el usuario";
                    //return RedirectToAction("GetAllAPI");
                }
                else
                {
                    ViewBag.Message = "no se puede eliminar correctemnte el usuario , Error: ";
                }
            }
            return PartialView("Modal");
        }
    }
}