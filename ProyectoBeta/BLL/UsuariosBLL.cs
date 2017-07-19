using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoBeta.BLL
{
    public class UsuariosBLL
    {
        public static List<Models.Usuarios> GetLista()
        {
            var lista = new List<Models.Usuarios>();
            using (var db = new Models.Context())
            {
                try
                {
                    lista = db.Usuarios.ToList();
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
