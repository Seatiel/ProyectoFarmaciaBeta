using ProyectoBeta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoBeta.Models
{
    public class LaboratoriosBLL
    {
        public static bool Insertar(Laboratorios laboratorio)
        {
            bool retorno = false;

            try
            {
                using (var db = new Context())
                {
                    db.Laboratorios.Add(laboratorio);
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

        public static Laboratorios Buscar(int id)
        {
            var db = new Context();

            return db.Laboratorios.Find(id);
        }

        public static void Eliminar(int id)
        {
            using (var db = new Context())
            {
                var laboratorio = new Laboratorios();

                laboratorio = db.Laboratorios.Find(id);

                db.Laboratorios.Remove(laboratorio);
                db.SaveChanges();
            }
        }

        public static void Modificar(int id, Laboratorios laboratorio)
        {
            using (var db = new Context())
            {
                var lab = new Laboratorios();
                lab = db.Laboratorios.Find(id);

                lab.Nombre = laboratorio.Nombre;
                db.SaveChanges();
            }
        }

        public static List<Laboratorios>GetLista()
        {
            var lista = new List<Laboratorios>();
            var db = new Context();

            lista = db.Laboratorios.ToList();

            return lista;

        }

        public static List<Laboratorios>GetLista(int id)
        {
            var lista = new List<Laboratorios>();
            var db = new Context();

            lista = db.Laboratorios.Where(l => l.LaboratorioId == id).ToList();

            return lista;

        }

        public static List<Laboratorios>GetLista(string nombre)
        {
            var lista = new List<Laboratorios>();
            var db = new Context();

            lista = db.Laboratorios.Where(l => l.Nombre == nombre).ToList();

            return lista;
        }
        
    }
}
