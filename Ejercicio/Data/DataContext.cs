using Ejercicio.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ejercicio.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Zona> Zonas { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Presentacion> Presentaciones { get; set; }
        public DbSet<Marca> Marcas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Producto>().HasIndex(x => x.Codigo).IsUnique();
            modelBuilder.Entity<Zona>().HasIndex(x => x.Descripcion).IsUnique();
            modelBuilder.Entity<Proveedor>().HasIndex(x => x.Descripcion).IsUnique();
            modelBuilder.Entity<Presentacion>().HasIndex(x => x.Descripcion).IsUnique();
            modelBuilder.Entity<Marca>().HasIndex(x => x.Descripcion).IsUnique();
        }
    }
}
