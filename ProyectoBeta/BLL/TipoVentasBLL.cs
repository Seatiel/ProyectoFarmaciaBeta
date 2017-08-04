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
            List<TipoVentas> lista = new List<TipoVentas>();
            using (var db = new Context())
            {
                try
                {
                    lista = db.TipoVentas.ToList();
                }
                catch (Exception)
                {

                    throw;
                }
                return lista;
            }         
        }
    }


}
