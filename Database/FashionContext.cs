using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project_md2.Models;
using Microsoft.EntityFrameworkCore;

namespace Project_md2.Database
{
  public class FashionContext : DbContext
  {
    public FashionContext(DbContextOptions<FashionContext> options)
        : base(options)
    {
    }

    public DbSet<Usuario> Usuarios { get; set; }
    //public DbSet<Pessoa> Pessoas { get; set; }
    public DbSet<Colecao> Colecoes { get; set; }
    public DbSet<Modelo> Modelos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
      var assembly = GetType().Assembly;
      modelBuilder.ApplyConfigurationsFromAssembly(assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      //optionsBuilder.UseSqlServer("labclothingcollectionbd");
    }
  }
}
