﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class OTorresCRUDEntities : DbContext
    {
        public OTorresCRUDEntities()
            : base("name=OTorresCRUDEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Vehiculo> Vehiculoes { get; set; }
    
        public virtual int UsuarioAdd(string nombre, string aPPATERNO, string aPMaterno, string correo, Nullable<int> edad)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var aPPATERNOParameter = aPPATERNO != null ?
                new ObjectParameter("APPATERNO", aPPATERNO) :
                new ObjectParameter("APPATERNO", typeof(string));
    
            var aPMaternoParameter = aPMaterno != null ?
                new ObjectParameter("APMaterno", aPMaterno) :
                new ObjectParameter("APMaterno", typeof(string));
    
            var correoParameter = correo != null ?
                new ObjectParameter("Correo", correo) :
                new ObjectParameter("Correo", typeof(string));
    
            var edadParameter = edad.HasValue ?
                new ObjectParameter("Edad", edad) :
                new ObjectParameter("Edad", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UsuarioAdd", nombreParameter, aPPATERNOParameter, aPMaternoParameter, correoParameter, edadParameter);
        }
    
        public virtual int UsuarioDelete(Nullable<int> idUsuario)
        {
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UsuarioDelete", idUsuarioParameter);
        }
    
        public virtual ObjectResult<UsuarioGetAll_Result> UsuarioGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<UsuarioGetAll_Result>("UsuarioGetAll");
        }
    
        public virtual ObjectResult<UsuarioGetById_Result> UsuarioGetById(Nullable<int> idUsuario)
        {
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<UsuarioGetById_Result>("UsuarioGetById", idUsuarioParameter);
        }
    
        public virtual int UsuarioUpdate(Nullable<int> idUsuario, string nombre, string aPPATERNO, string aPMATERNO, string correo, Nullable<int> edad)
        {
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(int));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var aPPATERNOParameter = aPPATERNO != null ?
                new ObjectParameter("APPATERNO", aPPATERNO) :
                new ObjectParameter("APPATERNO", typeof(string));
    
            var aPMATERNOParameter = aPMATERNO != null ?
                new ObjectParameter("APMATERNO", aPMATERNO) :
                new ObjectParameter("APMATERNO", typeof(string));
    
            var correoParameter = correo != null ?
                new ObjectParameter("Correo", correo) :
                new ObjectParameter("Correo", typeof(string));
    
            var edadParameter = edad.HasValue ?
                new ObjectParameter("Edad", edad) :
                new ObjectParameter("Edad", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UsuarioUpdate", idUsuarioParameter, nombreParameter, aPPATERNOParameter, aPMATERNOParameter, correoParameter, edadParameter);
        }
    
        public virtual int VehiculoAdd(string fechaReclamo, Nullable<int> horaPercanse, string tipoPercanse, Nullable<int> numeroPoliza, string nombreConductor, Nullable<int> contactoConductor, string detallesVehiculo, string dañosPrejuicios, Nullable<decimal> estimacionReparacion, Nullable<bool> estatus, byte[] imagen)
        {
            var fechaReclamoParameter = fechaReclamo != null ?
                new ObjectParameter("FechaReclamo", fechaReclamo) :
                new ObjectParameter("FechaReclamo", typeof(string));
    
            var horaPercanseParameter = horaPercanse.HasValue ?
                new ObjectParameter("HoraPercanse", horaPercanse) :
                new ObjectParameter("HoraPercanse", typeof(int));
    
            var tipoPercanseParameter = tipoPercanse != null ?
                new ObjectParameter("TipoPercanse", tipoPercanse) :
                new ObjectParameter("TipoPercanse", typeof(string));
    
            var numeroPolizaParameter = numeroPoliza.HasValue ?
                new ObjectParameter("NumeroPoliza", numeroPoliza) :
                new ObjectParameter("NumeroPoliza", typeof(int));
    
            var nombreConductorParameter = nombreConductor != null ?
                new ObjectParameter("NombreConductor", nombreConductor) :
                new ObjectParameter("NombreConductor", typeof(string));
    
            var contactoConductorParameter = contactoConductor.HasValue ?
                new ObjectParameter("ContactoConductor", contactoConductor) :
                new ObjectParameter("ContactoConductor", typeof(int));
    
            var detallesVehiculoParameter = detallesVehiculo != null ?
                new ObjectParameter("DetallesVehiculo", detallesVehiculo) :
                new ObjectParameter("DetallesVehiculo", typeof(string));
    
            var dañosPrejuiciosParameter = dañosPrejuicios != null ?
                new ObjectParameter("DañosPrejuicios", dañosPrejuicios) :
                new ObjectParameter("DañosPrejuicios", typeof(string));
    
            var estimacionReparacionParameter = estimacionReparacion.HasValue ?
                new ObjectParameter("EstimacionReparacion", estimacionReparacion) :
                new ObjectParameter("EstimacionReparacion", typeof(decimal));
    
            var estatusParameter = estatus.HasValue ?
                new ObjectParameter("Estatus", estatus) :
                new ObjectParameter("Estatus", typeof(bool));
    
            var imagenParameter = imagen != null ?
                new ObjectParameter("Imagen", imagen) :
                new ObjectParameter("Imagen", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("VehiculoAdd", fechaReclamoParameter, horaPercanseParameter, tipoPercanseParameter, numeroPolizaParameter, nombreConductorParameter, contactoConductorParameter, detallesVehiculoParameter, dañosPrejuiciosParameter, estimacionReparacionParameter, estatusParameter, imagenParameter);
        }
    
        public virtual ObjectResult<VehiculoGetAll_Result> VehiculoGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<VehiculoGetAll_Result>("VehiculoGetAll");
        }
    
        public virtual int VehiculoDelete(Nullable<int> numeroReclamo)
        {
            var numeroReclamoParameter = numeroReclamo.HasValue ?
                new ObjectParameter("NumeroReclamo", numeroReclamo) :
                new ObjectParameter("NumeroReclamo", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("VehiculoDelete", numeroReclamoParameter);
        }
    }
}
