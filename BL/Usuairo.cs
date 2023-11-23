using ML;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Usuairo
    {

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.OTorresCRUDEntities contex = new DL.OTorresCRUDEntities())
                {
                    var query = contex.UsuarioGetAll().ToList();
                    if (query != null)
                    {
                        result.Objects = new List<object>();

                        foreach (var obj in query)
                        {
                            ML.Usuario usuario = new ML.Usuario();
                            usuario.IdUsuario = obj.IdUsuario;
                            usuario.Nombre = obj.Nombre;
                            usuario.Paterno = obj.APPaterno;
                            usuario.Materno = obj.APMaterno;
                            usuario.Correo = obj.Correo;
                            usuario.Edad = obj.Edad.Value;

                            result.Objects.Add(usuario);
                            result.Correct = true;

                        }

                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrio un problema, la tabla no contiene información";

                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = true;
                result.ErrorMessage = ex.Message;
                result.ex = ex;

            }
            return result;
        }


        public static ML.Result GetById(int id)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.OTorresCRUDEntities context = new DL.OTorresCRUDEntities())
                {
                    var query = context.UsuarioGetById(id).FirstOrDefault();

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        ML.Usuario usuario = new ML.Usuario();
                        usuario.IdUsuario = query.IdUsuario;
                        usuario.Nombre = query.Nombre;
                        usuario.Paterno = query.APPaterno;
                        usuario.Materno = query.APMaterno;
                        usuario.Correo = query.Correo;
                        usuario.Edad = query.Edad.Value;

                        result.Object = usuario;
                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrio un problema, la tabla no contiene información";
                    }

                }
            }
            catch (Exception ex)
            {
                result.Correct = true;
                result.ErrorMessage = ex.Message;
                result.ex = ex;

            }
            return result;
        }

        public static ML.Result Add(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result(); 
            try
            {
                using (DL.OTorresCRUDEntities context = new DL.OTorresCRUDEntities())
                {

                    var query = context.UsuarioAdd(usuario.Nombre, usuario.Paterno, usuario.Materno, usuario.Correo, usuario.Edad);

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se puede agregar el registro de " + usuario.Nombre;

                    }
                }
            }
            catch (Exception e)
            {

                result.Correct = false;
                result.ErrorMessage = e.Message;
                result.ex = e;
            }

            return result;
        }

        public static ML.Result Update(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.OTorresCRUDEntities context = new DL.OTorresCRUDEntities())
                {
                    var query = context.UsuarioUpdate(usuario.IdUsuario, usuario.Nombre, usuario.Paterno, usuario.Materno,
                        usuario.Correo, usuario.Edad);
                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se actualizo el registro " + usuario.Nombre;
                    }

                }
            }
            catch (Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = e.Message;
                result.ex = e;
            }

            return result;
        }

        public static ML.Result Delete(int Id)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.OTorresCRUDEntities context = new DL.OTorresCRUDEntities())
                {
                    var query = context.UsuarioDelete(Id);

                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se elimino el regitros";
                    }
                }
            }

            catch (Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = e.Message;
                result.ex = e;
            }

            return result;
        }



        ///

        public static ML.Result GetAllEFView(ML.Usuario usuarioBusqueda)
        {
            ML.Result result = new ML.Result();
            //empleadoBusqueda.Nombre= (empleadoBusqueda.Nombre == null) ? "" : empleadoBusqueda.Nombre;
            //empleadoBusqueda.ApellidoPaterno = (empleadoBusqueda.ApellidoPaterno == null) ? "" : empleadoBusqueda.ApellidoPaterno;
            //empleadoBusqueda.ApellidoMaterno = (empleadoBusqueda.ApellidoMaterno == null) ? "" : empleadoBusqueda.ApellidoMaterno;
            //empleadoBusqueda.Empresa.IdEmpresa = (empleadoBusqueda.Empresa.IdEmpresa != 0) ? int.Parse("0") : empleadoBusqueda.Empresa.IdEmpresa ;

            usuarioBusqueda.Nombre = (usuarioBusqueda.Nombre != null) ? usuarioBusqueda.Nombre : "";
            usuarioBusqueda.Paterno = (usuarioBusqueda.Paterno != null) ? usuarioBusqueda.Paterno : "";
            usuarioBusqueda.Materno = (usuarioBusqueda.Materno != null) ? usuarioBusqueda.Materno : "";
            usuarioBusqueda.Edad = (usuarioBusqueda.Edad != 0) ? usuarioBusqueda.Edad : int.Parse("0");

            try
            {
                using (DL.OTorresCRUDEntities context = new DL.OTorresCRUDEntities())
                {
                    var resultQuery = context.UsuarioGetAllBusqueda(usuarioBusqueda.Nombre, usuarioBusqueda.Paterno, 
                        usuarioBusqueda.Materno, usuarioBusqueda.Edad).ToList();


                    if (resultQuery != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var obj in resultQuery)
                        {
                            ML.Usuario usuario = new ML.Usuario();
                            usuario.IdUsuario = obj.IdUsuario;
                            usuario.Nombre = obj.Nombre;
                            usuario.Paterno = obj.APPaterno;
                            usuario.Materno = obj.APMaterno;
                            usuario.Correo = obj.Correo;
                            usuario.Edad = obj.Edad.Value;

                            result.Objects.Add(usuario);
                            result.Correct = true;

                        }
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrio un error la tabla no contiene informacion ";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.ex = ex;
            }
            return result;
        }
    }
}
