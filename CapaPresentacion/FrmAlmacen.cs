using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System_sSale.Clases;
using System_sSale;
using System.Collections;

namespace CapaPresentacion
{
    public partial class FrmAlmacen : Form
    {
        BaseDeDatos BD = new BaseDeDatos();
        
        SqlConnection connection = new SqlConnection(BaseDeDatos.Cn);
        public FrmAlmacen()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void MostrarVenta()
        {
            using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM vent", connection))
            {
                DataTable table = new DataTable();
                adapter.Fill(table);

                dataGridView1.DataSource = table;
            }


        }

        private void MostrarEmpleado()
        {
            using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM empleado", connection))
            {
                DataTable table = new DataTable();
                adapter.Fill(table);

                dataGridView1.DataSource = table;
            }


        }

        private void MostrarCliente()
        {
            using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM tclien", connection))
            {
                DataTable table = new DataTable();
                adapter.Fill(table);

                dataGridView1.DataSource = table;
            }


        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbBuscar.Text))
                MessageBox.Show("Debe seleccionar lo que quiere buscar en 'Seleccionar'.");
            //Para el boton buscar
            try
            {
                connection.Open();
                if ((cmbBuscar.Text).Equals("Ventas") /*&& (txtBuscar.Text).Equals("Ventas")*/)
                {
                    

                    MostrarVenta();

                }

                

                if ((cmbBuscar.Text).Equals("Empleados") /*&& (txtBuscar.Text).Equals("Empleados")*/)
                {
                    
                    MostrarEmpleado();

                }
                

                if ((cmbBuscar.Text).Equals("Clientes") /*&& (txtBuscar.Text).Equals("Clientes")*/)
                {
                    

                    MostrarCliente();
                }
                connection.Close();

                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vuelva a Intentarlo pero seleccionando lo que quiere buscar");

            }
        }
    }
}
