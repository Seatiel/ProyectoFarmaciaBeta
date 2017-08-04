using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoBeta.Models
{
    public class VentasDetalle
    {
        [Key]
        public int DetalleId { get; set; }

        public int VentaId { get; set; }

        public int MedicinaId { get; set; }

        public string Medicina { get; set; }

        public int Cantidad { get; set; }

        public decimal Precio { get; set; }

        public decimal Monto { get; set; }

        public decimal Descuento { get; set; }

        public VentasDetalle()
        {

        }
    }
}
