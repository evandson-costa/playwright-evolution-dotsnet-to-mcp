namespace CadastroUsuario.Domain.Interfaces;

using CadastroUsuario.Domain.Entities;

public interface IUsuarioRepository
{
    Task AdicionarAsync(Usuario usuario);
    Task<bool> UnitOfWorkCommitAsync();
}