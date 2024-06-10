using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_sSale.Clases
{
    public class Rol
    {
        private int idrol;
        private string nombre;
        private string descripcion;
        private bool estado;

        // Constructor de la clase
        public Rol(int idrol, string nombre, string descripcion, bool estado)
        {
            this.idrol = idrol;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.estado = estado;
        }

        // Método para mostrar los datos del rol
        /*public void MostrarDatos()
        {
            MessageBox.Show($"Id: {idrol}\nNombre: {nombre}\nDescripción: {descripcion}\nEstado: {(estado ? "Activo" : "Inactivo")}");
        }*/

        // Propiedades para acceder a los atributos
        public int Idrol
        {
            get { return idrol; }
            set { idrol = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public bool Estado
        {
            get { return estado; }
            set { estado = value; }
        }
    }
}
