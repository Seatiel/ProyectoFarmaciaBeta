using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoBeta.Models
{
    public class ClaseMaestra
    {
        public Ventas Encabezado { get; set; }

        public List<VentasDetalle> Detalle { get; set; }

        public ClaseMaestra()
        {
            Detalle = new List<VentasDetalle>();
        }
    }
}
