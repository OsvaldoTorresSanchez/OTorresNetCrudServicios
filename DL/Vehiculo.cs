//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Vehiculo
    {
        public int NumeroReclamo { get; set; }
        public Nullable<System.DateTime> FechaReclamo { get; set; }
        public Nullable<int> HoraPercanse { get; set; }
        public string TipoPercanse { get; set; }
        public Nullable<int> NumeroPoliza { get; set; }
        public string NombreConductor { get; set; }
        public Nullable<int> ContactoConductor { get; set; }
        public string DetallesVehiculo { get; set; }
        public string DañosPrejuicios { get; set; }
        public Nullable<decimal> EstimacionReparacion { get; set; }
        public Nullable<bool> Estatus { get; set; }
        public byte[] Imagen { get; set; }
    }
}