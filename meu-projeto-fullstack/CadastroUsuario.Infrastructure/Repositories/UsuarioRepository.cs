namespace CadastroUsuario.Infrastructure.Repositories;

using CadastroUsuario.Domain.Entities;
using CadastroUsuario.Domain.Interfaces;
using CadastroUsuario.Infrastructure.Context;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly AppDbContext _context;

    public UsuarioRepository(AppDbContext context) => _context = context;

    public async Task AdicionarAsync(Usuario usuario) => await _context.Usuarios.AddAsync(usuario);

    public async Task<bool> UnitOfWorkCommitAsync() => await _context.SaveChangesAsync() > 0;
}