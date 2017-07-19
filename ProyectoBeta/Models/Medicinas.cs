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

        [StringLength(80, ErrorMessage ="El limite de este campo es de 80 caracteres")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Nombre { get; set; }

        [StringLength(80, ErrorMessage = "El limite de este campo es de 80 caracteres")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Descripcion { get; set; }

        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public decimal PrecioVenta { get; set; }

        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public decimal PrecioCompra { get; set; }

        [Display(Name = "Fecha de vencimiento")]
        [DataType(DataType.Date)]
        public DateTime FechaVencimiento { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int CantidadExistencia { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int LaboratorioId { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(80, ErrorMessage = "El limite de este campo es de 80 caracteres")]
        public string Especificaciones { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int CategoriaId { get; set; }

        public Medicinas()
        {

        }
    }
}
