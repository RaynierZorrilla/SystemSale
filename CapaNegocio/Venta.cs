using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows;
using System.Reflection;


namespace System_sSale.Clases
{
    public class Venta
    {
        
        public int Idventa { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public string Empleado { get; set; }
        public string Producto { get; set; }
        public string Tipo_comprobante { get; set; }
        public string Tipo_pago { get; set; }
        public string Fecha { get; set; }
        public decimal Itbis { get; set; }
        public decimal Total { get; set; }
        public bool Estado { get; set; }


    }
}
