using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System_sSale;

namespace CapaDatos
{
    public class DCliente
    {
        public static string Cn = "Data Source = LAPTOP-UFFK3NJM; Initial Catalog=APfacturacion; Integrated Security=true;";


        public SqlConnection conectarbd = new SqlConnection();
        public DCliente()
        {
            conectarbd.ConnectionString = Cn;
        }


        public DataTable D_listado()
        {
            SqlCommand cmd = new SqlCommand("sp_listar", conectarbd);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


    }
}
