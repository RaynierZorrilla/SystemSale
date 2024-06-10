using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }
       
        private void button4_Click(object sender, EventArgs e)
        {
            if (formIsOpen("RegistroVenta") == false)
            {
                RegistroVenta registro = new RegistroVenta();
            // Establece el título y el tamaño del formulario hijo
            registro.Size = new Size(850, 650);
            // Establece la posición inicial del formulario hijo como manual
            registro.StartPosition = FormStartPosition.Manual;
            // Calcula la ubicación del formulario hijo para centrarlo en el padre
            int x = this.Location.X + (this.Width - registro.Width) / 2;
            int y = this.Location.Y + (this.Height - registro.Height) / 2;
            // Establece la ubicación del formulario hijo
            registro.Location = new Point(x, y);
            registro.MdiParent = this;
            registro.Show();

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Mostrar el MessageBox con la opción de aceptar o cancelar
            DialogResult resultado = MessageBox.Show("¿Estás seguro de que quieres continuar?", "Confirmación", MessageBoxButtons.OKCancel);

            // Comprobar la respuesta del usuario
            if (resultado == DialogResult.OK)
            {
                // El usuario ha pulsado aceptar
                // Aquí iría el código que queremos que se ejecute si el usuario acepta

                Application.Exit();
            }
            else
            {
                // El usuario ha pulsado cancelar
                // Esto se deja vacio Porque al pulsar, se queda en la misma interfaz
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (formIsOpen("FrmCliente") == false)
            {
                FrmCliente Cl= new FrmCliente();
            // Establece el título y el tamaño del formulario hijo
            Cl.Size = new Size(850, 650);
            // Establece la posición inicial del formulario hijo como manual
            Cl.StartPosition = FormStartPosition.Manual;
            // Calcula la ubicación del formulario hijo para centrarlo en el padre
            int x = this.Location.X + (this.Width - Cl.Width) / 2;
            int y = this.Location.Y + (this.Height - Cl.Height) / 2;
            // Establece la ubicación del formulario hijo
            Cl.Location = new Point(x, y);
            Cl.MdiParent = this;
            Cl.Show();

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if(formIsOpen("AcercaDe") == false)
            {
            AcercaDe acercaDe = new AcercaDe();
            // Establece el título y el tamaño del formulario hijo
            acercaDe.Size = new Size(900, 550);
            // Establece la posición inicial del formulario hijo como manual
            acercaDe.StartPosition = FormStartPosition.Manual;
            // Calcula la ubicación del formulario hijo para centrarlo en el padre
            int x = this.Location.X + (this.Width - acercaDe.Width) / 2;
            int y = this.Location.Y + (this.Height - acercaDe.Height) / 2;
            // Establece la ubicación del formulario hijo
            acercaDe.Location = new Point(x, y);
            acercaDe.MdiParent = this;
            acercaDe.Show();
            }

        }

        bool formIsOpen(string nombre_form)
        {
            foreach (var form_hijo in this.MdiChildren)
            {
                if(form_hijo.Text == nombre_form)
                {
                    form_hijo.BringToFront();
                    return true;
                    
                }

                return false;
            }

            return false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (formIsOpen("FrmArticulo") == false)
            {
                FrmArticulo AR = new FrmArticulo();
                // Establece el título y el tamaño del formulario hijo
                AR.Size = new Size(830, 625);
                // Establece la posición inicial del formulario hijo como manual
                AR.StartPosition = FormStartPosition.Manual;
                // Calcula la ubicación del formulario hijo para centrarlo en el padre
                int x = this.Location.X + (this.Width - AR.Width) / 2;
                int y = this.Location.Y + (this.Height - AR.Height) / 2;
                // Establece la ubicación del formulario hijo
                AR.Location = new Point(x, y);
                AR.MdiParent = this;
                AR.Show();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (formIsOpen("FrmEmpleado") == false)
            {
                FrmEmpleado FE = new FrmEmpleado();
                // Establece el título y el tamaño del formulario hijo
                FE.Size = new Size(850, 650);
                // Establece la posición inicial del formulario hijo como manual
                FE.StartPosition = FormStartPosition.Manual;
                // Calcula la ubicación del formulario hijo para centrarlo en el padre
                int x = this.Location.X + (this.Width - FE.Width) / 2;
                int y = this.Location.Y + (this.Height - FE.Height) / 2;
                // Establece la ubicación del formulario hijo
                FE.Location = new Point(x, y);
                FE.MdiParent = this;
                FE.Show();

            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Principal_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (formIsOpen("FrmAlmacen") == false)
            {
                FrmAlmacen FA = new FrmAlmacen();
                // Establece el título y el tamaño del formulario hijo
                FA.Size = new Size(850, 650);
                // Establece la posición inicial del formulario hijo como manual
                FA.StartPosition = FormStartPosition.Manual;
                // Calcula la ubicación del formulario hijo para centrarlo en el padre
                int x = this.Location.X + (this.Width - FA.Width) / 2;
                int y = this.Location.Y + (this.Height - FA.Height) / 2;
                // Establece la ubicación del formulario hijo
                FA.Location = new Point(x, y);
                FA.MdiParent = this;
                FA.Show();

            }
        }
    }
}
