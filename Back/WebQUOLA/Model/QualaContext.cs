using Microsoft.EntityFrameworkCore;
using WebQUOLA.Objects.Entities;

namespace WebQUOLA.Model;

public class QualaContext : DbContext
{
    public QualaContext(DbContextOptions<QualaContext> options) : base(options)
    {
    }

    public DbSet<Sucursal> Sucursales { get; set; }
    public DbSet<Moneda> Monedas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Sucursal>()
            .ToTable("Sucursales")
            .HasKey(x => x.Id);

        modelBuilder.Entity<Sucursal>()
            .Property(x => x.Descripcion)
            .HasMaxLength(250)
            .IsRequired();

        modelBuilder.Entity<Sucursal>()
            .Property(x => x.Direccion)
            .HasMaxLength(250)
            .IsRequired();

        modelBuilder.Entity<Sucursal>()
            .Property(x => x.Identificacion)
            .HasMaxLength(250)
            .IsRequired();

        modelBuilder.Entity<Sucursal>()
            .Property(x => x.FechaCreacion)
            .IsRequired();

        modelBuilder.Entity<Moneda>()
            .ToTable("Monedas")
            .HasKey(x => x.Id);

        modelBuilder.Entity<Moneda>()
            .Property(x=> x.Nombre)
            .HasMaxLength(250)
            .IsRequired();

        modelBuilder.Entity<Moneda>()
        .Property(x => x.Codigo)
        .HasMaxLength(10)
        .IsRequired();
    }
}
