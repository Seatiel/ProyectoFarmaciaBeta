using ProyectoBeta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoBeta.Models
{
    public class CategoriasBLL
    {
        public static List<Categorias> GetLista()
        {
            var lista = new List<Categorias>();
            using (var db = new Context())
            {
                try
                {
                    lista = db.Categorias.ToList();
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
