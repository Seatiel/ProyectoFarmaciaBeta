using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoBeta.Models
{
    public class Ventas
    {
        [Key]
        public int VentaId { get; set; }

        public int TipoVentaId { get; set; }

        public string Medicina { get; set; }

        public int Cantidad { get; set; }

        public DateTime FechaVenta { get; set; }

        public decimal Total { get; set; }

        public Ventas()
        {

        }
    }
}
