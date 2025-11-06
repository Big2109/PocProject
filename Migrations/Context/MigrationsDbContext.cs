using Microsoft.EntityFrameworkCore;
using Migrations.Entities;
namespace Migrations.Context;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options)
        : base(options) { }
    public DbSet<Cliente> Cliente { get; set; }
    public DbSet<Usuario> Usuario { get; set; }
    public DbSet<Acesso> Acesso { get; set; }
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

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.ToTable("Usuario");
            entity.HasKey(e => e.GuidUsuario);
            entity.Property(e => e.GuidUsuario)
            .HasColumnType("uniqueidentifier");
            entity.Property(e => e.Nome)
                  .HasMaxLength(1000)
                  .IsRequired();
            entity.Property(e => e.NomeUsuario)
                  .HasMaxLength(1000)
                  .IsRequired();
            entity.Property(e => e.Email)
                  .HasMaxLength(1000)
                  .IsRequired();
            entity.Property(e => e.Senha)
                .HasMaxLength(1000)
                .IsRequired();
            entity.Property(e => e.HorarioAcesso)
            .HasColumnType("datetime2")
                .IsRequired();
        });

        modelBuilder.Entity<Acesso>(entity =>
        {
            entity.ToTable("Acesso");

            entity.HasKey(e => e.GuidUsuario);

            entity.Property(e => e.GuidUsuario)
                .HasColumnType("uniqueidentifier");

            entity.Property(e => e.HorarioAcesso)
                .HasColumnType("datetime2");

            entity.HasOne(e => e.Usuario)
                .WithOne(u => u.Acesso)
                .HasForeignKey<Acesso>(e => e.GuidUsuario);
        });
    }
}
