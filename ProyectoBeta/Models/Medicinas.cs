using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoBeta.Models
{
    public class Medicinas
    {
        [Key]
        public int MedicinaId { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public decimal PrecioVenta { get; set; }
        [Required]
        public decimal PrecioCompra { get; set; }
        [Required]
        public DateTime FechaVencimiento { get; set; }
        [Required]
        public int CantidadExistencia { get; set; }
        [Required]
        public int LaboratorioId { get; set; }
        [Required]
        public string Especificaciones { get; set; }
        [Required]
        public int CategoriaId { get; set; }

        public Medicinas()
        {

        }
    }
}
