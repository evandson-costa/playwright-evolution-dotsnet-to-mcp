using Microsoft.EntityFrameworkCore;
using CadastroUsuario.Domain.Entities;

namespace CadastroUsuario.Infrastructure.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Usuario>(b => {
            b.HasKey(x => x.Id);
            b.Property(x => x.Nome).IsRequired().HasMaxLength(100);
            b.Property(x => x.Cep).HasMaxLength(8);
        });
    }
}