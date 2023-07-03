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
  public class ModeloConfigurations : IEntityTypeConfiguration<Modelo>
  {
    public void Configure(EntityTypeBuilder<Modelo> builder)
    {
      builder.HasKey(u => u.Id);

      builder.Property(u => u.NomeModelo)
          .HasMaxLength(Modelo.NomeModeloMaxLength)
          .IsRequired();

      builder.Property(u => u.IdColecaoRelacionada)
          .HasConversion<int>()
          .IsRequired();

      builder.Property(u => u.Tipo)
          .HasConversion<int>()
          .IsRequired();

      builder.Property(u => u.Layout)
          .HasConversion<int>()
          .IsRequired();
    }
  }
}
