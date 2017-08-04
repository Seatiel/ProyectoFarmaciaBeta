using ProyectoBeta.Models;
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
            List<Usuarios> lista = new List<Usuarios>();
            using (var db = new Context())
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
