using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_sSale.Clases
{
    public class Categoria
    {
        public static object Nombre { get; private set; }
        public static object Descripcion { get; private set; }


        //Metodo Insertar

        public string Insertar(Categoria categoria) 
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Codigo

                SqlCon.ConnectionString = BaseDeDatos.Cn;
                SqlCon.Open();

                //Establecer el comando
                SqlCommand Sqlcmd = SqlCon.CreateCommand();
                Sqlcmd.CommandText = "categoria";
                Sqlcmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter ParIdcategoria = new SqlParameter();
                ParIdcategoria.ParameterName = "@idcategoria";
                ParIdcategoria.SqlDbType = System.Data.SqlDbType.Int;
                ParIdcategoria.Direction=System.Data.ParameterDirection.Output;
                Sqlcmd.Parameters.Add(ParIdcategoria);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = System.Data.SqlDbType.VarChar;
                ParNombre.Size = 100;
                ParNombre.Value = Categoria.Nombre;
                Sqlcmd.Parameters.Add(ParNombre);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "descripcion";
                ParDescripcion.SqlDbType = System.Data.SqlDbType.VarChar;
                ParDescripcion.Size = 200;
                ParDescripcion.Value = Categoria.Descripcion;
                Sqlcmd.Parameters.Add(ParDescripcion);

                SqlParameter ParEstado = new SqlParameter();
                ParDescripcion.ParameterName = "estado";
                ParDescripcion.SqlDbType = System.Data.SqlDbType.VarChar;
                ParDescripcion.SqlDbType = SqlDbType.Bit;
                ParDescripcion.Value = Categoria.Descripcion;
                Sqlcmd.Parameters.Add(ParEstado);

                //Ejecutar comando

                rpta= Sqlcmd.ExecuteNonQuery()==1?"OK":"NO se Ingreso el Registro:";

            }
            catch (Exception ex)
            {

                rpta = ex.Message;
            }

            finally 
            {
                if (SqlCon.State == System.Data.ConnectionState.Open) SqlCon.Close(); 
            
            }
            return rpta;
        
        
        
        }

        public string Editar(Categoria categoria)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Codigo

                SqlCon.ConnectionString = BaseDeDatos.Cn;
                SqlCon.Open();

                //Establecer el comando
                SqlCommand Sqlcmd = SqlCon.CreateCommand();
                Sqlcmd.CommandText = "categoria";
                Sqlcmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter ParIdcategoria = new SqlParameter();
                ParIdcategoria.ParameterName = "@idcategoria";
                ParIdcategoria.SqlDbType = System.Data.SqlDbType.Int;
                ParIdcategoria.Direction = System.Data.ParameterDirection.Output;
                Sqlcmd.Parameters.Add(ParIdcategoria);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = System.Data.SqlDbType.VarChar;
                ParNombre.Size = 100;
                ParNombre.Value = Categoria.Nombre;
                Sqlcmd.Parameters.Add(ParNombre);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "descripcion";
                ParDescripcion.SqlDbType = System.Data.SqlDbType.VarChar;
                ParDescripcion.Size = 200;
                ParDescripcion.Value = Categoria.Descripcion;
                Sqlcmd.Parameters.Add(ParDescripcion);

                SqlParameter ParEstado = new SqlParameter();
                ParDescripcion.ParameterName = "estado";
                ParDescripcion.SqlDbType = System.Data.SqlDbType.VarChar;
                ParDescripcion.SqlDbType = SqlDbType.Bit;
                ParDescripcion.Value = Categoria.Descripcion;
                Sqlcmd.Parameters.Add(ParEstado);

                //Ejecutar comando

                rpta = Sqlcmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Ingreso el Registro:";

            }
            catch (Exception ex)
            {

                rpta = ex.Message;
            }

            finally
            {
                if (SqlCon.State == System.Data.ConnectionState.Open) SqlCon.Close();

            }
            return rpta;
        }
    }
        
}
