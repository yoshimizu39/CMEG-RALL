using CMEG.Web.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMEG.Web.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<CentroAsistencial> CentrosAsistenciales { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Modelo> Modelos { get; set; }
        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Mantenimiento> Mantenimientos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CentroAsistencial>().HasIndex(ca => ca.Nombre).IsUnique();
        }
    }
}
