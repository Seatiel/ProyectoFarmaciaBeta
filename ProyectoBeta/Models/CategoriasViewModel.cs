using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProyectoBeta.Models
{
    public class CategoriasViewModel
    {
        public List<Medicinas> medicina { get; set; }
        public SelectList MyProperty { get; set; }
        public string categoria { get; set; }
    }
}
