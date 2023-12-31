﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

///Validaciones

namespace ML
{
    public class Vehiculo
    {
        public int NumeroReclamo { get; set; }


        public string FechaReclamo { get; set; }
        public int HoraPercanse { get; set; }
        public string TipoPercanse { get; set; }

        public int NumeroPoliza { get; set; }


        [Required(ErrorMessage = "Es obligatorio")]
        [Display(Name = "Nombre Conductor")]
        public string NombreConductor { get; set; }
        public int ContactoConductor { get; set; }
        public string DetallesVehiculo { get; set; }
        public string DañosPrejuicios { get; set; }
        public decimal EstimacionReparacion { get; set; }
        public byte[] Imagen { get; set; }
        public bool Statu { get; set; }
        public List<object> Vehiculos { get; set; }

        public string Error { get; set; }

    }
}
