using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;

namespace CapaPresentacion
{
    public partial class Login : Form
    {
        //PantallaPrincipal cerrar = new PantallaPrincipal();
       
        public Login()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection("server=LAPTOP-UFFK3NJM;database=SesionLg; integrated security=true");
        private void Form2_Load(object sender, EventArgs e)
        {

        }

        
        private void button1_Click(object sender, EventArgs e)
        {
             try 
            { 

             conn.Open();
             string consulta = "select * from Usuarios where nombre='" + textusuario.Text + "' and contraseña='" + textcontraseña.Text + "'";
             SqlCommand comando = new SqlCommand(consulta,conn);
             SqlDataReader lector;
             lector = comando.ExecuteReader();

                if (textusuario.Text == "" || textcontraseña.Text == "")
                    MessageBox.Show("Llene los espacios, porfavor");
                



                else if (lector.HasRows==true) 
             {
                    this.Hide();
                    Bienvenida bienvenida = new Bienvenida();
                    bienvenida.ShowDialog();
                    Principal pp = new Principal();
                    
                    
                    pp.Show();
                    
                    
                 
             }
             
             else
             {
                 MessageBox.Show("Incorrecto");
             }

             conn.Close();

             }catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }

           
        }

        private void textcontraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar== Convert.ToChar(Keys.Enter))
            {
                try
                {

                    conn.Open();
                    string consulta = "select * from Usuarios where nombre='" + textusuario.Text + "' and contraseña='" + textcontraseña.Text + "'";
                    SqlCommand comando = new SqlCommand(consulta, conn);
                    SqlDataReader lector;
                    lector = comando.ExecuteReader();

                    if (textusuario.Text == "" || textcontraseña.Text == "")
                        MessageBox.Show("Llene los espacios, porfavor");




                    else if (lector.HasRows == true)
                    {
                        this.Hide();
                        Bienvenida bienvenida = new Bienvenida();
                        bienvenida.ShowDialog();
                        Principal pp = new Principal();


                        pp.Show();
                       


                    }

                    else
                    {
                        MessageBox.Show("Incorrecto");
                    }

                    conn.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
