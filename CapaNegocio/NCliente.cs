using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace System_sSale.Clases
{
    public class NCliente
    {
        public int idCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public string Sexo { get; set; }

        public string Empleado { get; set; }


        


    }
}
