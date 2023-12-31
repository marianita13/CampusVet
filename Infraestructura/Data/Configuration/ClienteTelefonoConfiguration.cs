using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Data.Configuration
{
    public class ClienteTelefonoConfiguration : IEntityTypeConfiguration<ClienteTelefono>
    {
        public void Configure(EntityTypeBuilder<ClienteTelefono> builder)
        {
            // Aquí puedes configurar las propiedades de la entidad Marca
            // utilizando el objeto 'builder'.
            builder.ToTable("ClienteTelefono");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(p => p.Numero)
            .IsRequired()
            .HasMaxLength(50);

            builder.HasOne(p => p.Clientes)
            .WithMany(p => p.ClientesTelefonos)
            .HasForeignKey(p => p.IdCliente);
        }
    }
}