using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_md2.Models;
using Project_md2.Models.Enum;

namespace Project_md2.Database.Configurations
{
    public class UsuarioConfigurations : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.NomeCommpleto)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(u => u.Genero)
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(u => u.DataNascimento)
                .IsRequired();

            builder.Property(u => u.CpfCnpj)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(u => u.Telefone)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(u => u.Email)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(u => u.TipoUsuario)
                .HasConversion<int>()
                .IsRequired();

            builder.Property(u => u.Status)
                .HasConversion<int>()
                .IsRequired();
        }
    }
}
