using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NC
    {
      DCliente objdato = new DCliente();

        public DataTable N_listado()
        {
            return objdato.D_listado();
        }

    }
}

