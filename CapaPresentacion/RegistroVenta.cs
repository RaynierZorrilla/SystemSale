using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System_sSale;
using System.Security.Cryptography.X509Certificates;
using System_sSale.Clases;
using CapaNegocio;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection;
using System.Drawing.Text;
using System.Runtime.Remoting.Messaging;
using System.IO;

namespace CapaPresentacion
{
    public partial class RegistroVenta : Form
    {
        BaseDeDatos BD = new BaseDeDatos();
        Venta Vn = new Venta();
        

        SqlConnection connection = new SqlConnection(BaseDeDatos.Cn);

        string[,] ListaVenta = new string[200, 6];
        int fila = 0;

        //variable global para el Datagridview2
        DataTable dt;




        public RegistroVenta()
        {
            InitializeComponent();
            dataGridView1.CellDoubleClick += new DataGridViewCellEventHandler(dataGridView1_CellDoubleClick);

            //Inhabilitar el campo de texto ID venta
            //textIdVenta.Enabled = false;
        

        }
       
         


        private void btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RegistroVenta_Load(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Today.Date.ToString("d");
            lblPrecio.Text = (0).ToString("C", new CultureInfo("es-DO"));
            CrearDataTable();
        }

        
        private void cboProducto_SelectedIndexChanged(object sender, EventArgs e)
        {

            BD.abrir();

            
            Vn.Producto = cboProducto.Text;
            if (Vn.Producto.Equals("Piano")) Vn.Precio = 20500;
            if (Vn.Producto.Equals("Bateria")) Vn.Precio = 40900;
            if (Vn.Producto.Equals("Guitarra acustica")) Vn.Precio = 8100;
            if (Vn.Producto.Equals("Guitarra electrica")) Vn.Precio = 12000;
            if (Vn.Producto.Equals("Bajo")) Vn.Precio = 16000;
            if (Vn.Producto.Equals("Saxofon")) Vn.Precio = 10200;
            if (Vn.Producto.Equals("Trompeta")) Vn.Precio = 9500;
            if (Vn.Producto.Equals("In ear")) Vn.Precio = 3300;

            lblPrecio.Text = Vn.Precio.ToString("C", new CultureInfo("es-DO"));
        }

        private void btn_Registrar_Click(object sender, EventArgs e)
        {
            
            //Valinando
            if(cboProducto.SelectedIndex == -1)
                MessageBox.Show("Debe seleccionar un producto.");
            else if(textCantidad.Text == "")
                MessageBox.Show("Debe ingresar una cantidad.");
            else if (cboTipoPago.SelectedIndex == -1)
                MessageBox.Show("Debe seleccionar un tipo de pago.");

            
                

            
            else
            {
                
                MessageBox.Show("Venta exitosa");
                //capturando datos
                Vn.Producto = cboProducto.Text;
                Vn.Cantidad = Convert.ToInt32(textCantidad.Text);
                Vn.Tipo_pago = cboTipoPago.Text;
                Vn.Empleado = textEmpleado.Text;

                //prosecar calculos
                decimal subtotal = Vn.Cantidad * Vn.Precio;

                Vn.Producto= cboProducto.Text;
                Vn.Tipo_pago = cboTipoPago.Text;
                Vn.Cantidad = int.Parse(textCantidad.Text);
                Vn.Fecha= DateTime.Now.ToShortDateString();
                Vn.Precio = int.Parse(Vn.Precio.ToString());
                Vn.Total = Vn.Cantidad * Vn.Precio;
                
                
            }

            Insertar();
            



        }
        
        //CRUD
        public void Insertar()
        {
           
          

                using (SqlCommand command = new SqlCommand("INSERT INTO vent (Vn.Producto, Vn.Tipo_pago, Vn.Cantidad, Vn.Fecha_hora, Vn.Precio, Vn.Total, Vn.Empleado) VALUES (@producto, @tipo_pago, @cantidad, @fecha_hora, @precio, @total, @empleado)", connection))
                {
                    command.Parameters.AddWithValue("@producto", Vn.Producto);
                    command.Parameters.AddWithValue("@tipo_pago", Vn.Tipo_pago);
                    command.Parameters.AddWithValue("@cantidad", Vn.Cantidad);
                    command.Parameters.AddWithValue("@fecha_hora", Vn.Fecha);
                    command.Parameters.AddWithValue("@precio", Vn.Precio);
                    command.Parameters.AddWithValue("@total", Vn.Total);
                    command.Parameters.AddWithValue("@empleado", Vn.Empleado);

                connection.Open();
                    int result = command.ExecuteNonQuery();

                    // Check Error
                    if (result < 0)
                        MessageBox.Show("Error al guardar los datos en la base de datos.");
                }
            

           
                using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM vent", connection))
                {
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    dataGridView1.DataSource = table;
                }
            
                connection.Close();


            //btn_Cancelar_Click(sender, e);
        }
        public void CargarGrid2()
        {
            try
            {
                if(lblPrecio.Text != "" && textCantidad.Text != "" && cboTipoPago.Text != "" && lblFecha.Text != ""  && cboProducto.Text != "" && textEmpleado.Text != "")
                // Obtener los datos de la fila seleccionada

                ListaVenta[fila, 0] = lblPrecio.Text;
                ListaVenta[fila, 1] = textCantidad.Text;
                ListaVenta[fila, 2] = cboTipoPago.Text;
                ListaVenta[fila, 3] = lblFecha.Text;
                
                ListaVenta[fila, 5] = cboProducto.Text;
                ListaVenta[fila, 6] = textEmpleado.Text;

                

                dataGridView2.Rows.Add(ListaVenta[fila,0], ListaVenta[fila,1], ListaVenta[fila, 2], ListaVenta[fila, 3], ListaVenta[fila, 4], ListaVenta[fila, 5], ListaVenta[fila, 6]);
                fila++;

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex);
            }
            
        }
        private void Modificar()
        {
            connection.Open();

            string consula = "update vent set producto= '" + cboProducto.Text + "',tipo_pago='" + cboTipoPago.Text  +  "',cantidad='" + textCantidad.Text + "',empleado='" + textEmpleado.Text + "' where idvent='" + textIdVenta.Text + "';";
            SqlCommand comando = new SqlCommand(consula, connection);
            int Ca;
            Ca = comando.ExecuteNonQuery();
            if (Ca > 0)
            {
                MessageBox.Show("Registro modificado");
            }

            connection.Close();


        }
        private void Mostrar()
        {
            using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM vent", connection))
            {
                DataTable table = new DataTable();
                adapter.Fill(table);

                dataGridView1.DataSource = table;
            }


        }
        private void Eliminar()
        {
            connection.Open();

            string consulta = "delete from vent where idvent='" + textIdVenta.Text + "';";
            SqlCommand comando = new SqlCommand(consulta, connection);
            comando.ExecuteNonQuery();
            MessageBox.Show("Registro eliminado");

            connection.Close();
        }


        public void CostoAPagar()
        {

            decimal Finaltotal = 0;

            // Recorrer las filas del datagridview2
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                // Obtener el valor de la celda de la columna "total"
                object valor = dataGridView2.Rows[i].Cells["total"].Value;

                // Convertir el valor a decimal y sumarlo al total
                Finaltotal += Convert.ToDecimal(valor);
            }

            // Asignar el valor del total al lblCostoaPagar
            lblCostoAPagar.Text = Finaltotal.ToString();

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Obtener los datos de la fila seleccionada
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            Vn.Idventa = int.Parse(row.Cells[0].Value.ToString());
            Vn.Producto = row.Cells[6].Value.ToString();
            Vn.Tipo_pago = row.Cells[3].Value.ToString();
            Vn.Cantidad = int.Parse(row.Cells[2].Value.ToString());
            Vn.Empleado = row.Cells[7].Value.ToString();

            // Asignar los datos a los textbox o combobox correspondientes
            textIdVenta.Text = Vn.Idventa.ToString();
            cboProducto.Text = Vn.Producto;
            cboTipoPago.Text = Vn.Tipo_pago;
            textCantidad.Text = Vn.Cantidad.ToString();
            textEmpleado.Text = Vn.Empleado.ToString();
            
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            textIdVenta.Clear();
            cboProducto.Text = "(Seleccione producto)";
            cboTipoPago.Text = "(Seleccione tipo)";
            textCantidad.Clear();
            lblPrecio.Text = (0).ToString("C", new CultureInfo("es-DO"));
            cboProducto.Focus();

            BD.cerrar();
        }

        

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Valinando
            if (cboProducto.SelectedIndex == -1)
                MessageBox.Show("Debe seleccionar una Producto existente o modificarlo para el LISTADO DE VENTAS.");
            else if (textCantidad.Text == "")
                MessageBox.Show("Debe seleccionar una cantidad existente o modificarlo para el LISTADO DE VENTAS.");
            else if (cboTipoPago.SelectedIndex == -1)
                MessageBox.Show("Debe seleccionar un tipo existente o modificarlo para el LISTADO DE VENTAS.");

            /*decimal subtotal = Vn.Cantidad * Vn.Precio;
            Vn.Total = Vn.Cantidad * Vn.Precio;*/

            Modificar();
          
            
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (cmboBuscar.SelectedIndex == -1)
                    MessageBox.Show("Debe seleccionar lo que quiere buscar en 'Seleccionar'.");

            //Para el boton buscar
            try
            {
                if (string.IsNullOrEmpty(cmboBuscar.Text) && string.IsNullOrEmpty(txtBuscar.Text))
                {
                    Mostrar();
                }

                else
                {
                    string columna = cmboBuscar.SelectedItem.ToString();
                    string valor = txtBuscar.Text;
                    string query = "SELECT * FROM vent WHERE " + columna + " LIKE '%" + valor + "%'";
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


        private void button2_Click(object sender, EventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {
            Mostrar();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CrearDataTable()
        {
            // Crear el DataTable con las columnas
            dt = new DataTable();
            dt.Columns.Add("Precio");
            dt.Columns.Add("Producto");
            dt.Columns.Add("TipoPago");
            dt.Columns.Add("Cantidad");
            dt.Columns.Add("Fecha");
            dt.Columns.Add("Empleado");
            dt.Columns.Add("Total");

            // Asignar el DataTable al datagridview2
            dataGridView2.DataSource = dt;
        }
        private void button1_Click_1(object sender, EventArgs e)
        {

            //Valinando
            if (cboProducto.SelectedIndex == -1)
                MessageBox.Show("Debe seleccionar un producto.");
            else if (textCantidad.Text == "")
                MessageBox.Show("Debe ingresar una cantidad.");
            else if (cboTipoPago.SelectedIndex == -1)
                MessageBox.Show("Debe seleccionar un tipo de pago.");

            //capturando datos
            Vn.Producto = cboProducto.Text;
            Vn.Cantidad = Convert.ToInt32(textCantidad.Text);
            Vn.Tipo_pago = cboTipoPago.Text;
            Vn.Empleado = textEmpleado.Text;

            //prosecar calculos
            decimal subtotal = Vn.Cantidad * Vn.Precio;

            Vn.Producto = cboProducto.Text;
            Vn.Tipo_pago = cboTipoPago.Text;
            Vn.Cantidad = int.Parse(textCantidad.Text);
            Vn.Fecha = DateTime.Now.ToShortDateString();
            Vn.Precio = int.Parse(Vn.Precio.ToString());
            Vn.Total = Vn.Cantidad * Vn.Precio;

            try
            {

                // Crear el DataRow con los datos de los controles
                DataRow dr1 = dt.NewRow();
                dr1.ItemArray = new object[] { lblPrecio.Text, cboProducto.Text, cboTipoPago.Text, textCantidad.Text, lblFecha.Text, textEmpleado.Text, Vn.Total };

                // Agregar el DataRow al DataTable
                dt.Rows.Add(dr1);

                CostoAPagar();
            }
            catch (Exception )
            {

                MessageBox.Show("Vuelve a intentarlo llenando cada espacio correspondiente");
            }

            
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (dataGridView2.DataSource == null || dataGridView1.Rows.Count == 0)
            {
                
                // Mostrar un mensaje de advertencia
                MessageBox.Show("Debe registrar y guardar la venta para ser vendida", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
            else
            {
                // Obtener la ruta de la carpeta predeterminada del proyecto
                string projectPath = Path.GetDirectoryName(Application.StartupPath);

            // Crear una subcarpeta llamada Ventas si no existe
            Directory.CreateDirectory(Path.Combine(projectPath, "Ventas"));

            // Crear un nombre de archivo con la fecha y hora actual
            string fileName = "Venta_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";

            // Crear un objeto StreamWriter con el nombre y la ruta del archivo
            StreamWriter writer = new StreamWriter(Path.Combine(projectPath, "Ventas", fileName));

            // Escribir el encabezado del archivo
                writer.Write("                         **********************************************\n");
                writer.Write("                                     Sistema De Ventas\n\n");
                writer.Write("                         **********************************************\n");
                writer.Write("Precio       Producto       TipoPago       Cantidad        Fecha         Empleado           Subtotal\n");
                writer.Write("-----------------------------------------------------------------------------------------------------------------------------------------------\n");

                // Recorrer las filas y columnas del datagriview
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    
                    // Crear una variable para almacenar la línea de texto
                    string line = "";

                    
                    // Recorrer las celdas de la fila
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        // Añadir el valor de la celda a la línea, separado por una coma
                        line += cell.Value + ",      ";
                    }

                    // Eliminar la última coma de la línea
                    line = line.TrimEnd(',');

                    // Escribir la línea en el archivo
                    writer.WriteLine(line);

                    
                }
                writer.Write("TOTAL:");
                writer.Write(lblCostoAPagar.Text);
                // Escribir el pie del archivo
                writer.Write("-----------------------------------------------------------------------------------------------------------------------------------------------\n\n");
                writer.Write("                               **********************************\n");
                writer.Write("                                *     Gracias por preferirnos    *\n");
                writer.Write("                               **********************************\n");

                // Obtener la ruta de la carpeta predeterminada del proyecto
                //string projectPath = Path.GetDirectoryName(Application.StartupPath);

                // Mostrar la ruta en la consola
                Console.WriteLine(projectPath);

                // Cerrar el objeto StreamWriter
                writer.Close();

            MessageBox.Show("Compra Facturada");
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
        }
    }


}
