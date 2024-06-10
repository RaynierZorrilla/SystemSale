
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System;


namespace System_sSale
{
    public class BaseDeDatos
    {
        public static string Cn = "Data Source = LAPTOP-UFFK3NJM; Initial Catalog=APfacturacion; Integrated Security=true;";
        public SqlConnection conectarbd = new SqlConnection();



        public BaseDeDatos()
        {
            conectarbd.ConnectionString = Cn;
        }

        public void abrir()
        {
            try
            {
                conectarbd.Open();
                Console.WriteLine("Conexion abierta");
                

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al abrir BD" + ex.ToString());

            }

        }
        public void cerrar()
        {
            conectarbd.Close();
        }
    }
}