using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProyectoBeta.Models
{
    public class Usuarios
    {
        [Key]
        public int UsuarioId { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Email { get; set; }

        public string NombreUsuario { get; set; }

        public string Clave { get; set; }

        public string ConfirmarClave { get; set; }
    }
}
