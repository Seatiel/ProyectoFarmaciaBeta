using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoBeta.Models;

namespace ProyectoBeta.Models
{
    public class Context : DbContext
    {
        public Context() : base()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-34DIMD7\\SEATIEL;Initial Catalog=FarmaciaDb;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        public DbSet<ProyectoBeta.Models.Laboratorios> Laboratorios { get; set; }

        public DbSet<ProyectoBeta.Models.Categorias> Categorias { get; set; }

        public DbSet<ProyectoBeta.Models.Medicinas> Medicinas { get; set; }

        public DbSet<ProyectoBeta.Models.TipoVentas> TipoVentas { get; set; }

        public DbSet<ProyectoBeta.Models.VentasDetalle> VentasDetalle { get; set; }

        public DbSet<ProyectoBeta.Models.Ventas> Ventas { get; set; }
    }
}
