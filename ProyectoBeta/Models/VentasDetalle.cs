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
        public int Id { get; set; }

        public int VentaId { get; set; }

        public string MedicinaId { get; set; }

        public decimal Precio { get; set; }

        public int Cantidad { get; set; }

        public VentasDetalle()
        {

        }
    }
}
