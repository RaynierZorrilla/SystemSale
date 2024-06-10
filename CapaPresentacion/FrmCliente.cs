using CapaDatos;
using CapaNegocio;
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
using System_sSale;
using System_sSale.Clases;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CapaPresentacion
{
   
    public partial class FrmCliente : Form
    {
       BaseDeDatos BD = new BaseDeDatos();
       NCliente Nc = new NCliente();
       SqlConnection connection = new SqlConnection(BaseDeDatos.Cn);
       DateTime fechaNacimiento;


        public FrmCliente()
        {
            InitializeComponent();

            //dataGridView1.CellDoubleClick += new DataGridViewCellEventHandler(dataGridView1_CellDoubleClick);

        }




        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cmbBuscar.SelectedIndex == -1)
                MessageBox.Show("Debe seleccionar lo que quiere buscar en 'Seleccionar'.");
            //Para el boton buscar
            try
            {
                if (string.IsNullOrEmpty(cmbBuscar.Text) && string.IsNullOrEmpty(txtBuscar.Text))
                {
                    Mostrar();
                }

                else
                {
                    string columna = cmbBuscar.SelectedItem.ToString();
                    string valor = txtBuscar.Text;
                    string query = "SELECT * FROM tclien WHERE " + columna + " LIKE '%" + valor + "%'";
                    using (SqlConnection connection = new SqlConnection(BaseDeDatos.Cn))
                    {
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Vuelva a Intentarlo pero seleccionando lo que quiere buscar");

            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //Valinando
            if (txtNombre.Text == "")
                MessageBox.Show("Debe ingresar su nombre.");
            else if (txtApellido.Text == "")
                MessageBox.Show("Debe ingresar su apellido.");
            else if (txtCedula.Text == "")
                MessageBox.Show("Debe ingresar su numero de Cedula.");
            else if (cmbSexo.Text == "")
                MessageBox.Show("Debe ingresar su tipo se sexo.");
            else if (txtTelefono.Text == "")
                MessageBox.Show("Debe ingresar su numero de telefono.");

            else
            {

                MessageBox.Show("Venta exitosa");
                //capturando datos
                Nc.Nombre = txtNombre.Text;
                Nc.Apellido = txtApellido.Text;
                Nc.Cedula = (txtCedula.Text);
                Nc.Email = txtEmail.Text;
                Nc.Telefono = (txtTelefono.Text);
                Nc.Sexo = cmbSexo.Text;
                Nc.Direccion = txtDireccion.Text;
                






            Insertar();

            }

        }

         
        public void Insertar()
        {
            

            try
            {
                using (SqlCommand command = new SqlCommand("INSERT INTO tclien (Nc.Nombre, Nc.Apellido, Nc.Cedula, Nc.Email, Nc.Telefono, Nc.Sexo, Nc.Direccion) VALUES (@nombre, @apellido, @cedula, @email, @telefono, @sexo, @direccion)", connection))
            {
                command.Parameters.AddWithValue("@nombre", Nc.Nombre);
                command.Parameters.AddWithValue("@apellido", Nc.Apellido);
                command.Parameters.AddWithValue("@cedula", Nc.Cedula);
                command.Parameters.AddWithValue("@email", Nc.Email);
                command.Parameters.AddWithValue("@telefono", Nc.Telefono);
                command.Parameters.AddWithValue("@sexo", Nc.Sexo);
                command.Parameters.AddWithValue("@direccion", Nc.Direccion);
                

                connection.Open();
                int result = command.ExecuteNonQuery();

                // Check Error
                if (result < 0)
                    MessageBox.Show("Error al guardar los datos en la base de datos.");
            }



            using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM tclien", connection))
            {
                DataTable table = new DataTable();
                adapter.Fill(table);

                dataGridView1.DataSource = table;
            }

            //btn_Cancelar_Click(sender, e);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error:" + ex);
            }

            connection.Close();

        }
        
        private void Mostrar()
        {
            using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM tclien", connection))
            {
                DataTable table = new DataTable();
                adapter.Fill(table);

                dataGridView1.DataSource = table;
            }


        }

        private void Modificar()
        {
            connection.Open();

            string consula = "update tclien set nombre= '" + txtNombre.Text + "',apellido='" + txtApellido.Text + "',telefono='" + txtTelefono.Text + "',sexo='" + cmbSexo.Text + "',cedula='" + txtCedula.Text + "',direccion='" + txtDireccion.Text + "',email='" + txtEmail.Text + "' where idce='" + txtIdCliente.Text + "';";
            SqlCommand comando = new SqlCommand(consula, connection);
            int Ca;
            Ca = comando.ExecuteNonQuery();
            if (Ca > 0)
            {
                MessageBox.Show("Registro modificado");
            }

            connection.Close();


        }

        private void Limpiar()
        {
            txtIdCliente.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtTelefono.Clear();
            cmbSexo.Text = "(Seleccione)";
            txtCedula.Clear();            
            txtDireccion.Clear();
            txtEmail.Clear();
        }

        private void Eliminar()
        {
            connection.Open();

            string consulta = "delete from tclien where idce='" + txtIdCliente.Text + "';";
            SqlCommand comando = new SqlCommand(consulta, connection);
            comando.ExecuteNonQuery();
            MessageBox.Show("Registro eliminado");

            connection.Close();
        }



        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            //Nc.Fecha = dtpFecha.Value;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            //Valinando
            if (txtNombre.Text == "")
                MessageBox.Show("Debe escribir un nombre existente o modificarlo para el LISTADO DE CLIENTES.");
            else if (txtApellido.Text == "")
                MessageBox.Show("Debe seleccionar un apellido existente o modificarlo para el LISTADO DE CLIENTES.");
            else if (txtTelefono.Text == "")
                MessageBox.Show("Debe seleccionar un telefono existente o modificarlo para el LISTADO DE CLIENTES.");
            else if (txtCedula.Text == "")
                MessageBox.Show("Debe seleccionar una cedula existente o modificarlo para el LISTADO DE CLIENTES.");
            else if (txtDireccion.Text == "")
                MessageBox.Show("Debe seleccionar una direccion existente o modificarlo para el LISTADO DE CLIENTES.");
            else if (cmbSexo.SelectedIndex == -1)
                MessageBox.Show("Debe seleccionar una sexo existente o modificarlo para el LISTADO DE CLIENTES.");

            Modificar();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Mostrar();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Obtener los datos de la fila seleccionada
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            Nc.idCliente = int.Parse(row.Cells[0].Value.ToString());
            Nc.Nombre = row.Cells[1].Value.ToString();
            Nc.Apellido = row.Cells[2].Value.ToString();
            Nc.Telefono = row.Cells[3].Value.ToString();
            Nc.Sexo = row.Cells[4].Value.ToString();
            Nc.Cedula = row.Cells[5].Value.ToString();
            Nc.Direccion = row.Cells[6].Value.ToString();
            Nc.Email = row.Cells[7].Value.ToString();


            // Asignar los datos a los textbox o combobox correspondientes
            txtIdCliente.Text = Nc.idCliente.ToString();
            txtNombre.Text = Nc.Nombre.ToString();
            txtApellido.Text = Nc.Apellido.ToString();
            txtTelefono.Text = Nc.Telefono.ToString();
            cmbSexo.Text = Nc.Sexo;
            txtCedula.Text = Nc.Cedula.ToString();
            txtDireccion.Text = Nc.Direccion.ToString();
            txtEmail.Text = Nc.Email.ToString();
        }

        private void FrmCliente_Load(object sender, EventArgs e)
        {

        }
    }
}
