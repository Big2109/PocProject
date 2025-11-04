using Microsoft.EntityFrameworkCore;
using Migrations.Entities;
namespace Migrations.Context;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options)
        : base(options) { }
    public DbSet<Cliente> Cliente { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.ToTable("Cliente");
            entity.HasKey(e => e.GuidCliente);
            entity.Property(e => e.GuidCliente)
            .HasColumnType("uniqueidentifier");
            entity.Property(e => e.Nome)
                  .HasMaxLength(1000)
                  .IsRequired();
            entity.Property(e => e.Email)
                  .HasMaxLength(1000)
                  .IsRequired();
        });
    }
}
