using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoBeta.Models
{
    public class TipoVentas
    {
        [Key]
        public int TipoVentaId { get; set; }

        public string Descripcion { get; set; }

        public TipoVentas()
        {

        }
    }
}
