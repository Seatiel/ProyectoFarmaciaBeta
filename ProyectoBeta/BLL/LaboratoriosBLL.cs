using Microsoft.EntityFrameworkCore;
using ProyectoBeta.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
                    lab = db.Laboratorios.Find(id);
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
                    if (Buscar(lab.LaboratorioId) != null)
                    {
                        db.Entry(lab).State = EntityState.Modified;
                        if (db.SaveChanges() > 0)
                            return true;
                    }
                    else
                    {
                        return Guardar(lab);
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return false;
        }

        //public static bool Modificar(Laboratorios lab)
        //{
        //    using (var db = new Context())
        //    {
        //        try
        //        {
        //            db.Entry(lab).State = EntityState.Modified;
        //            if (db.SaveChanges() > 0)
        //                return true;
        //        }
        //        catch (Exception)
        //        {

        //            throw;
        //        }
        //    }
        //    return false;
        //}

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

        public static List<Laboratorios>GetListar(int id)
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

        //public static List<Laboratorios>GetLista(string nombre)
        //{
        //    var lista = new List<Laboratorios>();
        //    using (var db = new Context())
        //    {
        //        try
        //        {
        //            lista = db.Laboratorios.Where(l => l.Nombre == nombre).ToList();
        //        }
        //        catch (Exception)
        //        {

        //            throw;
        //        }
        //        return lista;
        //    }               
        //}

        public static List<Laboratorios> GetListaFecha(DateTime Desde, DateTime Hasta)
        {
            List<Laboratorios> lista = new List<Laboratorios>();
            using (var db = new Context())
            {
                try
                {
                    lista = db.Laboratorios.Where(p => p.FechaIngreso >= Desde && p.FechaIngreso <= Hasta).ToList();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return lista;
        }

        public static int Identity()
        {
            int identity = 0;
            string con =
            @"Data Source=clientesserverdb.database.windows.net;Initial Catalog=FarmaciaDb;Integrated Security=False;User ID=matap91;Password=theworlds.91;Connect Timeout=15;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection db = new SqlConnection(con))
            {
                try
                {
                    db.Open();
                    SqlCommand comando = new SqlCommand("SELECT IDENT_CURRENT('Laboratorios')", db);
                    identity = Convert.ToInt32(comando.ExecuteScalar());
                    db.Close();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return identity;
        }

    }
}
