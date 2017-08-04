using Microsoft.EntityFrameworkCore;
using ProyectoBeta.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ProyectoBeta.Models
{
    public class MedicinasBLL
    {

        public static bool Guardar(Medicinas medicina)
        {
            using (var conexion = new Context())
            {
                try
                {
                    conexion.Medicinas.Add(medicina);
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

        public static Medicinas Buscar(int? medicinaId)
        {
            Medicinas medicina = null;
            using (var db = new Context())
            {
                try
                {
                    medicina = db.Medicinas.Find(medicinaId);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return medicina;
        }

        public static bool Modificar(Medicinas med)
        {
            using (var db = new Context())
            {
                try
                {
                    db.Entry(med).State = EntityState.Modified;
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

        public static bool Eliminar(Medicinas med)
        {
            using (var db = new Context())
            {
                try
                {
                    db.Entry(med).State = EntityState.Deleted;
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

        public static List<Medicinas> GetLista()
        {
            List<Medicinas> lista = null;
            using (var db = new Context())
            {
                try
                {
                    lista = db.Medicinas.ToList();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return lista;
        }

        public static List<Medicinas> GetListId(int id)
        {
            List<Medicinas> list = new List<Medicinas>();
            using (var db = new Context())
            {
                try
                {
                    list = db.Medicinas.Where(p => p.MedicinaId == id).ToList();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return list;
        }

        public static bool Eliminar(int? id)
        {
            try
            {
                return Eliminar(Buscar(id));
            }
            catch (Exception)
            {

                throw;
            }
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
                    SqlCommand comando = new SqlCommand("SELECT IDENT_CURRENT('Medicinas')", db);
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
