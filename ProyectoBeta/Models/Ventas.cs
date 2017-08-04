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
        [Required]
        public int TipoVentaId { get; set; }
        [Required]
        public DateTime FechaVenta { get; set; }
        //[Required]
        //public string Medicina { get; set; }
        [Required]
        public int Cantidad { get; set; }      

        public decimal SubTotal { get; set; }

        public decimal ITBIS { get; set; }
        
        public decimal Total { get; set; }

        public Ventas()
        {

        }
    }
}
