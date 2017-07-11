using ProyectoBeta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoBeta.Models
{
    public class MedicinasBLL
    {
        public static bool Insertar(Medicinas med)
        {
            bool retorno = false;

            try
            {
                using (var db = new Context())
                {
                    db.Medicinas.Add(med);
                    db.SaveChanges();
                    db.Dispose();
                    retorno = true;
                }
            }catch(Exception)
            {
                throw;
            }

            return retorno;
        }

        public static List<Medicinas> GetLista()
        {
            var lista = new List<Medicinas>();
            using (var conexion = new Context())
            {
                try
                {
                    lista = conexion.Medicinas.ToList();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return lista;

        }

    }
}
