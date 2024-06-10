using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_sSale.Clases
{
    public class Articulo
    {
        // Atributos de la clase
        private int idarticulo;
        private int idcategoria;
        private string codigo;
        private string nombre;
        private decimal precio_venta;
        private int stock;
        private string descripcion;
        private bool estado;

        // Constructor de la clase
        public Articulo(int idarticulo, int idcategoria, string codigo, string nombre, decimal precio_venta, int stock, string descripcion, bool estado)
        {
            this.idarticulo = idarticulo;
            this.idcategoria = idcategoria;
            this.codigo = codigo;
            this.nombre = nombre;
            this.precio_venta = precio_venta;
            this.stock = stock;
            this.descripcion = descripcion;
            this.estado = estado;
        }

        // Método para mostrar los datos del artículo
        /*public void MostrarDatos()
        {
            MessageBox.Show($"Id artículo: {idarticulo}\nId categoría: {idcategoria}\nCódigo: {codigo}\nNombre: {nombre}\nPrecio de venta: {precio_venta}\nStock: {stock}\nDescripción: {descripcion}\nEstado: {(estado ? "Activo" : "Inactivo")}");
        }*/

        // Propiedades para acceder a los atributos
        public int Idarticulo
        {
            get { return idarticulo; }
            set { idarticulo = value; }
        }

        public int Idcategoria
        {
            get { return idcategoria; }
            set { idcategoria = value; }
        }

        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public decimal Precio_venta
        {
            get { return precio_venta; }
            set { precio_venta = value; }
        }

        public int Stock
        {
            get { return stock; }
            set { stock = value; }
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
