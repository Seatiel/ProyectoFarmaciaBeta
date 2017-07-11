using ProyectoBeta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoBeta.Models
{
    public class TipoVentasBLL
    {
        public static List<TipoVentas>GetLista()
        {
            var lista = new List<TipoVentas>();
            var db = new Context();

            lista = db.TipoVentas.ToList();

            return lista;
        }
    }
}
