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

namespace CapaPresentacion
{
    public partial class FrmEmpleado : Form
    {
        BaseDeDatos BD = new BaseDeDatos();
        NEmpleado NE = new NEmpleado();
        SqlConnection connection = new SqlConnection(BaseDeDatos.Cn);
        public FrmEmpleado()
        {
            InitializeComponent();


        }



        //CRUD
        private void Limpiar()
        {
            txtIdEmpleado.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtTelefono.Clear();
            cmbSexo.Text = "(Seleccione)";
            txtCedula.Clear();
            txtDireccion.Clear();
            txtEmail.Clear();
            txtRol.Clear();
        }
        private void Mostrar()
        {
            using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM empleado", connection))
            {
                DataTable table = new DataTable();
                adapter.Fill(table);

                dataGridView1.DataSource = table;
            }


        }
        public void Insertar()
        {


            try
            {
                using (SqlCommand command = new SqlCommand("INSERT INTO empleado (NE.Nombre, NE.Apellido, NE.Rol, NE.Cedula, NE.Email, NE.Telefono, NE.Sexo, NE.Direccion) VALUES (@nombre, @apellido, @rol , @cedula, @email, @telefono, @sexo, @direccion)", connection))
                {
                    command.Parameters.AddWithValue("@nombre", NE.Nombre);
                    command.Parameters.AddWithValue("@apellido", NE.Apellido);
                    command.Parameters.AddWithValue("@rol", NE.Rol);
                    command.Parameters.AddWithValue("@cedula", NE.Cedula);
                    command.Parameters.AddWithValue("@email", NE.Email);
                    command.Parameters.AddWithValue("@telefono", NE.Telefono);
                    command.Parameters.AddWithValue("@sexo", NE.Sexo);
                    command.Parameters.AddWithValue("@direccion", NE.Direccion);


                    connection.Open();
                    int result = command.ExecuteNonQuery();

                    // Check Error
                    if (result < 0)
                        MessageBox.Show("Error al guardar los datos en la base de datos.");
                }



                using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM empleado", connection))
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
        private void Modificar()
        {
            connection.Open();

            string consula = "update empleado set nombre= '" + txtNombre.Text + "',apellido='" + txtApellido.Text + "',telefono='" + txtTelefono.Text + "',sexo='" + cmbSexo.Text + "',rol='" + txtRol.Text + "',cedula='" + txtCedula.Text + "',direccion='" + txtDireccion.Text + "',email='" + txtEmail.Text + "' where ID='" + txtIdEmpleado.Text + "';";
            SqlCommand comando = new SqlCommand(consula, connection);
            int Ca;
            Ca = comando.ExecuteNonQuery();
            if (Ca > 0)
            {
                MessageBox.Show("Registro modificado");
            }

            connection.Close();


        }
        private void Eliminar()
        {

            try
            {
                connection.Open();
                string consulta = "delete from empleado where ID='" + txtIdEmpleado.Text + "';";
                SqlCommand comando = new SqlCommand(consulta, connection);
                comando.ExecuteNonQuery();
                MessageBox.Show("Registro eliminado");
            }
            catch (Exception ex)
            {

                MessageBox.Show("No se pudo eliminar el registro. Error:" + ex);
            }

            connection.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void FrmEmpleado_Load(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
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
                NE.Nombre = txtNombre.Text;
                NE.Apellido = txtApellido.Text;
                NE.Cedula = (txtCedula.Text);
                NE.Email = txtEmail.Text;
                NE.Telefono = (txtTelefono.Text);
                NE.Sexo = cmbSexo.Text;
                NE.Direccion = txtDireccion.Text;
                NE.Rol = txtRol.Text;


                Insertar();

            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Mostrar();
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            // Mostrar el MessageBox con la opción de aceptar o cancelar
            DialogResult resultado = MessageBox.Show("¿Estás seguro de que quieres Eliminar?", "Confirmación", MessageBoxButtons.OKCancel);

            // Comprobar la respuesta del usuario
            if (resultado == DialogResult.OK)
            {
                // El usuario ha pulsado aceptar
                // Aquí iría el código que queremos que se ejecute si el usuario acepta
                Eliminar();

            }
            else
            {
                // El usuario ha pulsado cancelar
                // Esto se deja vacio Porque al pulsar, se queda en la misma interfaz
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Modificar();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
            MessageBox.Show("Cancelado");
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
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
                    string query = "SELECT * FROM empleado WHERE " + columna + " LIKE '%" + valor + "%'";
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

        private void dataGridView1_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            // Obtener los datos de la fila seleccionada
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            NE.idEmpleado = int.Parse(row.Cells[0].Value.ToString());
            NE.Nombre = row.Cells[1].Value.ToString();
            NE.Apellido = row.Cells[2].Value.ToString();
            NE.Sexo = row.Cells[3].Value.ToString(); ;
            NE.Rol = row.Cells[4].Value.ToString();
            NE.Cedula = row.Cells[5].Value.ToString();
            NE.Direccion = row.Cells[6].Value.ToString();
            NE.Telefono = row.Cells[7].Value.ToString();
            NE.Email = row.Cells[8].Value.ToString();


            // Asignar los datos a los textbox o combobox correspondientes
            txtIdEmpleado.Text = NE.idEmpleado.ToString();
            txtNombre.Text = NE.Nombre.ToString();
            txtApellido.Text = NE.Apellido.ToString();
            cmbSexo.Text = NE.Sexo;
            txtRol.Text = NE.Rol.ToString();
            txtCedula.Text = NE.Cedula.ToString();
            txtTelefono.Text = NE.Telefono.ToString();
            txtDireccion.Text = NE.Direccion.ToString();
            txtEmail.Text = NE.Email.ToString();

            
        }

        /*private void dataGridView1_DoubleClick_1(object sender, EventArgs e)
        {
           
            this.txtIdEmpleado.Text = Convert.ToString(this.dataGridView1.CurrentRow.Cells["ID"]);
            this.txtNombre.Text = Convert.ToString(this.dataGridView1.CurrentRow.Cells["nombre"]);
            this.txtApellido.Text = Convert.ToString(this.dataGridView1.CurrentRow.Cells["apellido"]);
            this.cmbSexo.Text = Convert.ToString(this.dataGridView1.CurrentRow.Cells["sexo"]);
            this.txtRol.Text = Convert.ToString(this.dataGridView1.CurrentRow.Cells["rol"]);
            this.txtCedula.Text = Convert.ToString(this.dataGridView1.CurrentRow.Cells["cedula"]);
            this.txtDireccion.Text = Convert.ToString(this.dataGridView1.CurrentRow.Cells["direccion"]);
            this.txtTelefono.Text = Convert.ToString(this.dataGridView1.CurrentRow.Cells["telefono"]);
            this.txtEmail.Text = Convert.ToString(this.dataGridView1.CurrentRow.Cells["email"]);

            txtIdEmpleado.Text = NE.idEmpleado.ToString();
            txtNombre.Text = NE.Nombre.ToString();
            txtApellido.Text = NE.Apellido.ToString();
            cmbSexo.Text = NE.Sexo;
            txtRol.Text = NE.Rol.ToString();
            txtCedula.Text = NE.Cedula.ToString();
            txtTelefono.Text = NE.Telefono.ToString();
            txtDireccion.Text = NE.Direccion.ToString();
            txtEmail.Text = NE.Email.ToString();

            this.tabControl1.SelectedIndex = 1;
        }*/

    }
}
