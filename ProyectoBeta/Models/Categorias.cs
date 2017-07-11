using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoBeta.Models
{
    public class Categorias
    {
        [Key]
        public int CategoriaId { get; set; }

        public string Descripcion { get; set; }

        public Categorias()
        {

        }
    }
}
