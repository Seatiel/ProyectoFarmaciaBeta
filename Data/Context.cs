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
            optionsBuilder.UseSqlServer("Data Source=clientesserverdb.database.windows.net;Initial Catalog=FarmaciaDb;Integrated Security=False;User ID=matap91;Password=theworlds.91;Connect Timeout=15;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        public DbSet<ProyectoBeta.Models.Laboratorios> Laboratorios { get; set; }

        public DbSet<ProyectoBeta.Models.Categorias> Categorias { get; set; }

        public DbSet<ProyectoBeta.Models.Medicinas> Medicinas { get; set; }

        public DbSet<ProyectoBeta.Models.TipoVentas> TipoVentas { get; set; }

        public DbSet<ProyectoBeta.Models.VentasDetalle> VentasDetalle { get; set; }

        public DbSet<ProyectoBeta.Models.Ventas> Ventas { get; set; }
    }
}
