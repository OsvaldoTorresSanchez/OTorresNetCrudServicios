using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Usuario
    {

        public int IdUsuario { get; set; }

        public string Nombre { get; set; }

        public string Paterno { get; set; }

        public string Materno { get; set; }

        public string Correo { get; set; }

        public int Edad { get; set; }

        public List<object> Usuarios { get; set; }
    }
}
