using Microsoft.EntityFrameworkCore;
using ProyectoBeta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoBeta.Models
{
    public class LaboratoriosBLL
    {

        public static bool Guardar(Laboratorios lab)
        {
            using (var conexion = new Context())
            {
                try
                {
                    conexion.Laboratorios.Add(lab);
                    if (conexion.SaveChanges() > 0)
                    {
                        return true;
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return false;
        }


        public static Laboratorios Buscar(int? id)
        {
            Laboratorios lab = null;
            using (var db = new Context())
            {
                try
                {
                    lab = db.Laboratorios.Find(lab);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return lab;
        }

        public static bool Eliminar(Laboratorios lab)
        {
            using (var db = new Context())
            {
                try
                {
                    db.Entry(lab).State = EntityState.Deleted;
                    if (db.SaveChanges() > 0)
                        return true;
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return false;
        }

        public static bool Modificar(Laboratorios lab)
        {
            using (var db = new Context())
            {
                try
                {
                    db.Entry(lab).State = EntityState.Modified;
                    if (db.SaveChanges() > 0)
                        return true;
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return false;
        }

        public static List<Laboratorios>GetLista()
        {
            var lista = new List<Laboratorios>();
            using (var db = new Context())
            {
                try
                {
                    lista = db.Laboratorios.ToList();
                }
                catch (Exception)
                {

                    throw;
                }
                return lista;
            }        
        }

        public static List<Laboratorios>GetLista(int id)
        {
            var lista = new List<Laboratorios>();
            using (var db = new Context())
            {
                try
                {
                    lista = db.Laboratorios.Where(l => l.LaboratorioId == id).ToList();
                }
                catch (Exception)
                {

                    throw;
                }
                return lista;
            }
        }

        public static List<Laboratorios>GetLista(string nombre)
        {
            var lista = new List<Laboratorios>();
            using (var db = new Context())
            {
                try
                {
                    lista = db.Laboratorios.Where(l => l.Nombre == nombre).ToList();
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
