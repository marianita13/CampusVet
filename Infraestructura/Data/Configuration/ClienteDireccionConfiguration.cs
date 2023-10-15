using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Data.Configuration
{
    public class ClienteDireccionConfiguration : IEntityTypeConfiguration<ClienteDireccion>
    {
        public void Configure(EntityTypeBuilder<ClienteDireccion> builder)
        {
            // Aquí puedes configurar las propiedades de la entidad Marca
            // utilizando el objeto 'builder'.
            builder.ToTable("ClienteDireccion");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(p => p.TipoDeVia)
            .IsRequired()
            .HasMaxLength(50);

            builder.Property(p => p.NumeroPri)
            .IsRequired()
            .HasColumnType("int");

            builder.Property(p => p.Letra)
            .HasMaxLength(1);

            builder.Property(p => p.Bis)
            .HasMaxLength(3);

            builder.Property(p => p.LetraSec)
            .HasMaxLength(2);

            builder.Property(p => p.Cardinal)
            .HasMaxLength(10);

            builder.Property(p => p.NumeroSec)
            .IsRequired()
            .HasColumnType("int");

            builder.Property(p => p.LetraTer)
            .HasMaxLength(10);

            builder.Property(p => p.NumeroTer)
            .IsRequired()
            .HasColumnType("int");

            builder.Property(p => p.CardinalSec)
            .HasMaxLength(10);

            builder.Property(p => p.Complemento)
            .HasMaxLength(50);

            builder.Property(p => p.CodigoPostal)
            .HasMaxLength(10);

            builder.HasOne(a => a.Clientes)
            .WithOne(b => b.ClienteDireccion)
            .HasForeignKey<ClienteDireccion>(b => b.IdCliente);

            builder.HasOne(p => p.Ciudades)
            .WithOne(p => p.ClienteDireccion)
            .HasForeignKey<ClienteDireccion>(p => p.IdCiudad);
        }

    }
}