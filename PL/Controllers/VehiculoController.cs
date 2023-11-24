using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;

namespace PL.Controllers
{
    public class VehiculoController : Controller
    {
        // GET: Vehiculo
        public ActionResult Index()
        {
            return View();
        }

        // GET: Vehiculo
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Vehiculo vehiculo = new ML.Vehiculo();
            vehiculo.Vehiculos = new List<object>();
            ML.Result result = BL.Vehiculo.GetAllEF();


            if (result.Correct)
            {
                vehiculo.Vehiculos = result.Objects;
            }
            else
            {
                ViewBag.Message = result.ErrorMessage;
            }
            return View(vehiculo);
        }


        [HttpGet]
        public ActionResult Formulario(int? NumeroReclamo)
        {

            ML.Vehiculo vehiculo = new ML.Vehiculo();
            vehiculo.Vehiculos = new List<object>();

            if (NumeroReclamo > 0)
            {
                ML.Result result = BL.Vehiculo.GetById((int)NumeroReclamo);

                if (result.Correct)
                {
                    vehiculo = (ML.Vehiculo)result.Object;
                }
            }
            else
            {
                return View(vehiculo);
            }

            return View(vehiculo);
        }

        [HttpPost]
        public ActionResult Formulario(ML.Vehiculo vehiculo, HttpPostedFileBase fuimgUsuario)
        {
            if (ModelState.IsValid)//Validaaciones
            {
                if (fuimgUsuario != null)
                {
                    vehiculo.Imagen = this.ConvertTobytes(fuimgUsuario);
                }
                if (vehiculo.NumeroReclamo == 0)
                {
                    ML.Result result = BL.Vehiculo.AddEF(vehiculo);

                    if (result.Correct)
                    {

                        ViewBag.Message = "Se ha ingresado correctamente el registro";

                    }
                    else
                    {
                        ViewBag.Message = "no se ingresado correctemnte el registro , Error: " + result.ErrorMessage;
                    }
                }
                else
                {
                    ML.Result result = BL.Vehiculo.UpdateEF(vehiculo);
                    if (result.Correct)
                    {
                        ViewBag.Message = "Se ha actualizado correctamente el registro";

                    }
                    else
                    {
                        ViewBag.Message = "no se actualizado correctemnte el registro , Error: " + result.ErrorMessage;
                    }

                }
                return PartialView("Modal");

                //return View(usuario);
            }
            else
            {
                return View(vehiculo);
            }
        }

        //Imagen
        public byte[] ConvertTobytes(HttpPostedFileBase image)
        {
            byte[] imageBytes = null;
            BinaryReader reader = new BinaryReader(image.InputStream);
            imageBytes = reader.ReadBytes((int)image.ContentLength);
            return imageBytes;
        }

        public ActionResult Delete(int NumeroReclamo)
        {
            ML.Result result = BL.Vehiculo.Delete(NumeroReclamo);

            if (result.Correct)
            {
                ViewBag.Message = "Se elimino correctamente el registro";
            }
            else
            {
                ViewBag.Message = "No se elimino correctamente el registros" + NumeroReclamo + result.ErrorMessage;

            }


            return View("Modal");
        }

        /////// Toggle
        public JsonResult UpdateStatu(int NumeroReclamo, bool Statu)
        {
            ML.Vehiculo vehiculo = new ML.Vehiculo();
            ML.Result result = BL.Vehiculo.GetById(NumeroReclamo);

            if (result.Correct)
            {
                vehiculo = ((ML.Vehiculo)result.Object);
                vehiculo.Statu = (vehiculo.Statu) ? false : true;

                ML.Result resultUpdateStatu = BL.Vehiculo.UpdateEF(vehiculo);

                ViewBag.Message = "Se actualizo el statu del usuario";

            }
            else
            {
                ViewBag.Message = "No se actualizo el statu del usuario";


            }
            return Json(result.Objects);
        }

        ////// Carga masiva de archivos

        [HttpGet]
        public ActionResult CargaArchivo()
        {
            ML.Vehiculo vehiculo = new ML.Vehiculo();

            return View(vehiculo);
        }

        [HttpPost]
        public ActionResult CargaArchivo(ML.Vehiculo vehiculo, HttpPostedFileBase cargaMasiva)
        {
            ML.Result result = new ML.Result();

            if (cargaMasiva == null)
            {
                var lista = (List<Object>)Session["ListEmpleados"];
                vehiculo.Vehiculos = lista;
                CargaDatosTxt(vehiculo);
                Session.Remove("ListEmpleados");
                ViewBag.Message = "Datos cargados ";
                return PartialView("Modal");
            }
            string fileExtension = Path.GetExtension(cargaMasiva.FileName);
            //{
            //if (fileExtension.Equals(".txt", StringComparison.OrdinalIgnoreCase) || fileExtension.Equals(".xlsx", StringComparison.OrdinalIgnoreCase))
            if (fileExtension == ".txt")
            {
                if (Session["ListEmpleados"] == null)
                {
                    string direccionExcel = Server.MapPath("~/Files/Txt/") + Path.GetFileNameWithoutExtension(cargaMasiva.FileName) + '-' + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";

                    cargaMasiva.SaveAs(direccionExcel);

                    vehiculo = PrevisualizarTxt(vehiculo, cargaMasiva);
                    //Lista de empleados
                    //Guardadr sesion
                    Session["ListEmpleados"] = vehiculo.Vehiculos;

                }
                else
                {
                    //Extraer la infromacion de la sesion lista de empleos

                }

            }
            else
            {

            }
            //}
            return View(vehiculo);

        }

        public static ML.Vehiculo PrevisualizarTxt(ML.Vehiculo vehiculo, HttpPostedFileBase cargaMasiva)
        {
            vehiculo.Vehiculos = new List<object>();
            using (StreamReader file = new StreamReader(cargaMasiva.InputStream))
            {
                try
                {
                    string line;
                    line = file.ReadLine();
                    while ((line = file.ReadLine()) != null)
                    {
                        var campos = line.Split('|'); // Dividir la línea en campos usando '|'

                        ML.Vehiculo VehiculoItem = new ML.Vehiculo();
                        VehiculoItem.FechaReclamo = campos[0];
                        VehiculoItem.HoraPercanse = int.Parse(campos[1]);
                        VehiculoItem.TipoPercanse = campos[2];
                        VehiculoItem.NumeroPoliza = int.Parse(campos[3]);
                        VehiculoItem.NombreConductor = campos[4];
                        VehiculoItem.ContactoConductor = int.Parse(campos[5]);
                        VehiculoItem.DetallesVehiculo = campos[6];
                        VehiculoItem.DañosPrejuicios = campos[7];
                        VehiculoItem.EstimacionReparacion = decimal.Parse(campos[8]);
                        VehiculoItem.Statu = bool.TryParse(campos[9], out bool statu) ? statu : true; ;
                        //VehiculoItem.Imagen = byte.Parse(campos[10]); 
                        //VehiculoItem.Imagen = Encoding.UTF8.GetBytes(campos[10]); 


                        vehiculo.Vehiculos.Add(VehiculoItem);

                    }
                }
                catch (IOException ex)
                {

                }
            }
            return vehiculo;

        }


        public static ML.Vehiculo PrevisualizarExcel(ML.Vehiculo vehiculo, string rutaExel, string conexion)
        {
            using (OleDbConnection file = new OleDbConnection(conexion + rutaExel))
            {
                try
                {
                    string query = "SELECT * FROM [Hoja 1$]";
                    using (OleDbCommand context = new OleDbCommand())
                    {
                        context.CommandText = query;
                        context.Connection = file;

                        OleDbDataAdapter data = new OleDbDataAdapter(context);
                        data.SelectCommand = context;

                        DataTable tableEmpleado = new DataTable();
                        data.Fill(tableEmpleado);

                        if (tableEmpleado.Rows.Count > 0)
                        {

                            vehiculo.Vehiculos = new List<object>();

                            foreach (DataRow row in tableEmpleado.Rows)
                            {

                                ML.Vehiculo vehiculoItem = new ML.Vehiculo();
                                vehiculoItem.FechaReclamo = row[0].ToString();
                                vehiculoItem.HoraPercanse = int.Parse(row[1].ToString());
                                vehiculoItem.TipoPercanse = row[2].ToString();
                                vehiculoItem.NumeroPoliza = int.Parse(row[3].ToString());
                                vehiculoItem.NombreConductor = row[4].ToString();
                                vehiculoItem.ContactoConductor = int.Parse(row[5].ToString());
                                vehiculoItem.DetallesVehiculo = row[6].ToString();
                                vehiculoItem.DañosPrejuicios = row[7].ToString();
                                vehiculoItem.EstimacionReparacion = decimal.Parse(row[8].ToString());

                                vehiculo.Vehiculos.Add(vehiculoItem);
                            }
                        }
                    }
                }
                catch (IOException ex)
                {

                }
            }
            return vehiculo;

        }



        public void CargaDatosTxt(ML.Vehiculo vehiculo)
        {

            List<string> resultLines = new List<string>();

            foreach (ML.Vehiculo vehiculoItem in vehiculo.Vehiculos)
            {
                ML.Result result = BL.Vehiculo.AddEF(vehiculoItem);
                if (result.Correct)
                {
                    resultLines.Add("La inserccion del Empleado" + vehiculo.NumeroPoliza + "Fue exitoso");
                    result.Correct = true;
                }
                else
                {
                    resultLines.Add("Hubo un erro al actualizar de Empleado" + vehiculo.NumeroPoliza + "Error" + result.ErrorMessage);
                    result.Correct = false;

                }
            }

            var fecha = DateTime.Now.ToString("dd-MM-yyyy HHmmss");
            string path = Server.MapPath("~/Files/ArchivosTxt/" + "CargaMasivaTxtL_" + fecha + ".txt");

            using (StreamWriter archvioError = System.IO.File.CreateText(path))
            {
                foreach (string line in resultLines)
                {
                    archvioError.WriteLine(line);
                }
            }
        }


    }
}