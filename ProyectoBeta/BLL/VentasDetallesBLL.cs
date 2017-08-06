using Microsoft.EntityFrameworkCore;
using ProyectoBeta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoBeta.Models
{
    public class VentasDetallesBLL
    {
        public static bool Guardar(VentasDetalle detalle)
        {
            using (var db = new Context())
            {
                try
                {
                    db.VentasDetalle.Add(detalle);
                    if (db.SaveChanges() > 0)
                    {
                        var med = MedicinasBLL.Buscar(detalle.MedicinaId);
                        if (med.MedicinaId == 1)
                        {
                            med.CantidadExistencia = med.CantidadExistencia - detalle.Cantidad;
                            return MedicinasBLL.Modificar(med);
                        }
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

        public static VentasDetalle Buscar(int? detalleId)
        {
            VentasDetalle detalle = null;
            using (var db = new Context())
            {
                try
                {
                    detalle = db.VentasDetalle.Find(detalleId);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return detalle;
        }

        public static bool Modificar(VentasDetalle detalle)
        {
            using (var db = new Context())
            {
                try
                {
                    if (Buscar(detalle.DetalleId) != null)
                    {
                        db.Entry(detalle).State = EntityState.Modified;
                        if (db.SaveChanges() > 0)
                            return true;
                    }
                    else
                    {
                        return Guardar(detalle);
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return false;
        }

        public static bool Eliminar(VentasDetalle detalle)
        {
            using (var db = new Context())
            {
                try
                {
                    var med = MedicinasBLL.Buscar(detalle.MedicinaId);
                    int cant = detalle.Cantidad;

                    db.Entry(detalle).State = EntityState.Deleted;
                    if (db.SaveChanges() > 0)
                    {
                        if (med.MedicinaId == 1)
                        {
                            med.CantidadExistencia = med.CantidadExistencia + cant;
                            return MedicinasBLL.Modificar(med);
                        }
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

        //public static List<VentasDetalle> Listar(int? ventaId)
        //{
        //    List<VentasDetalle> listado = null;
        //    using (var db = new Context())
        //    {
        //        try
        //        {
        //            listado = db.VentasDetalle.Where(d => d.VentaId == ventaId).ToList();
        //        }
        //        catch (Exception)
        //        {

        //            throw;
        //        }
        //    }
        //    return listado;
        //}

        public static List<VentasDetalle> Listar(int? ventaId)
        {
            List<VentasDetalle> listado = null;
            using (var db = new Context())
            {
                try
                {
                    listado = db.VentasDetalle.
                        Where(d => d.VentaId == ventaId).
                        OrderBy(d => d.DetalleId).ToList();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return listado;
        }

        public static bool Guardar(List<VentasDetalle> detalles)
        {
            bool resultado = false;
            using (var db = new Context())
            {
                try
                {
                    foreach (VentasDetalle detail in detalles)
                    {
                        resultado = Guardar(detail);
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return resultado;
        }

        public static bool Modificar(List<VentasDetalle> detalles)
        {
            bool resultado = false;
            try
            {
                foreach (VentasDetalle detail in detalles)
                {
                    resultado = Modificar(detail);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return resultado;
        }

        public static bool Eliminar(int? detalleId)
        {
            try
            {
                return Eliminar(Buscar(detalleId));
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static bool Eliminar(List<VentasDetalle> detalle)
        {
            bool resultado = false;
            try
            {
                foreach (var detail in detalle)
                {
                    resultado = Eliminar(detail);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return resultado;
        }

        //public static bool Insertar(List<VentasDetalle> detalles)
        //{
        //    bool resultado = false;
        //    using (var db = new Context())
        //    {
        //        try
        //        {
        //            foreach (VentasDetalle detail in detalles)
        //            {
        //                db.VentasDetalle.Add(detail);
        //                db.SaveChanges();
        //                resultado = true;
        //            }
        //        }
        //        catch (Exception)
        //        {

        //                throw;
        //        }
        //    }
        //    return resultado;
        //}
    }
}
