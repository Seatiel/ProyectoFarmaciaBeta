using Microsoft.EntityFrameworkCore;
using ProyectoBeta.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ProyectoBeta.Models
{
    public class VentasBLL
    {
        public static bool Guardar(ClaseMaestra venta)
        {
            bool resultado = false;
            using (var db = new Context())
            {
                try
                {
                    db.Ventas.Add(venta.Encabezado);
                    if (db.SaveChanges() > 0)
                    {
                        resultado = VentasDetallesBLL.Guardar(venta.Detalle);
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return resultado;
        }

        public static ClaseMaestra Buscar(int? ventaid)
        {
            ClaseMaestra venta = null;
            using (var db = new Context())
            {
                try
                {
                    venta = new ClaseMaestra()
                    {
                        Encabezado = db.Ventas.Find(ventaid)
                    };
                    if (venta.Encabezado != null)
                    {
                        venta.Detalle =
                        VentasDetallesBLL.Listar(venta.Encabezado.VentaId);
                    }
                    else
                    {
                        venta = null;
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return venta;
        }

        public static bool Modificar(ClaseMaestra venta)
        {
            bool resultado = false;
            using (var db = new Context())
            {
                try
                {
                    db.Entry(venta.Encabezado).State = EntityState.Modified;
                    if (db.SaveChanges() > 0)
                    {
                        resultado = VentasDetallesBLL.Modificar(venta.Detalle);
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return resultado;
        }

        public static bool Eliminar(ClaseMaestra venta)
        {
            bool resultado = false;
            using (var db = new Context())
            {
                try
                {
                    if (VentasDetallesBLL.Eliminar(venta.Detalle))
                    {
                        db.Entry(venta.Encabezado).State = EntityState.Deleted;
                        resultado = db.SaveChanges() > 0;
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return resultado;
        }

        public static List<Ventas> Listar()
        {
            List<Ventas> listado = null;
            using (var db = new Context())
            {
                try
                {
                    listado = db.Ventas.ToList();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return listado;
        }

        public static bool Eliminar(int? ventaId)
        {
            try
            {
                return Eliminar(Buscar(ventaId));
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static bool Guardar(Ventas venta)
        {
            using (var db = new Context())
            {
                try
                {
                    db.Ventas.Add(venta);
                    if (db.SaveChanges() > 0)
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

        public static Ventas BuscarEncabezado(int? ventaId)
        {
            Ventas venta = null;
            using (var db = new Context())
            {
                try
                {
                    venta = db.Ventas.Find(ventaId);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return venta;
        }

        public static bool EliminarEncabezado(int? ventaId)
        {
            using (var db = new Context())
            {
                try
                {
                    db.Entry(BuscarEncabezado(ventaId)).State = EntityState.Deleted;
                    if (db.SaveChanges() > 0)
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

        public static bool ModificarEncabezado(int? ventaId)
        {
            using (var db = new Context())
            {
                try
                {
                    db.Entry(BuscarEncabezado(ventaId)).State = EntityState.Modified;
                    if (db.SaveChanges() > 0)
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
                    SqlCommand comando = new SqlCommand("SELECT IDENT_CURRENT('Ventas')", db);
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

        //public static List<Ventas> Listar(int? clienteId)
        //{
        //    List<Facturas> listado = null;
        //    using (var conexion = new DigitalServicesDB())
        //    {
        //        try
        //        {
        //            listado = conexion.Factura.
        //            Where(f => f.IdCliente == clienteId).
        //            OrderBy(f => f.Fecha).ToList();
        //        }
        //        catch (Exception)
        //        {

        //            throw;
        //        }
        //    }
        //    return listado;
        //}

        //public static bool Insertar (Ventas venta)
        //{
        //    bool retorno = false;
        //    try
        //    {
        //        using (var db = new Context())
        //        {
        //            db.Ventas.Add(venta);
        //            db.SaveChanges();
        //            retorno = true;
        //        }
        //    }catch(Exception)
        //    {
        //        throw;
        //    }

        //    return retorno;
        //}

    }
}
