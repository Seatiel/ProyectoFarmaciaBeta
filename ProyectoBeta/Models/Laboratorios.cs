using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoBeta.Models
{
    public class Laboratorios
    {
        [Key]
        public int LaboratorioId { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public DateTime FechaIngreso { get; set; }

        public Laboratorios()
        {

        }
    }
}
