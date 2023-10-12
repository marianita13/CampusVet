using System.Reflection;
using Core.entities;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Data
{
    public class AnimalsVetContext: DbContext
    {
        public AnimalsVetContext(DbContextOptions options)
            : base(options){ }

        public DbSet<Cliente> Clientes {get; set;}
        public DbSet<Pais> Paises {get; set;}
        public DbSet<Departamento> Departamentos {get; set;}
        public DbSet<Ciudad> Ciudades {get; set;}
        public DbSet<Mascota> Mascotas {get; set;}
        public DbSet<Raza> Razas {get; set;}
        public DbSet<Servicio> Servicios {get; set;}
        public DbSet<ClienteDireccion> ClienteDirecciones {get; set;}
        public DbSet<ClienteTelefono> ClienteTelefonos {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}