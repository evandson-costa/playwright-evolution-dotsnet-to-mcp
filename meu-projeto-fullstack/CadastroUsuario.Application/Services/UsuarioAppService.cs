namespace CadastroUsuario.Application.Services;

using CadastroUsuario.Domain.Entities;
using CadastroUsuario.Domain.Interfaces;

public class UsuarioAppService
{
    private readonly ICepService _cepService;
    private readonly IUsuarioRepository _repository;

    public UsuarioAppService(ICepService cepService, IUsuarioRepository repository)
    {
        _cepService = cepService;
        _repository = repository;
    }

   public async Task<Usuario> CriarUsuarioComCepAsync(string nome, string email, string cep)
{
    var endereco = await _cepService.BuscarEnderecoPorCepAsync(cep);
    if (endereco == null) throw new Exception("CEP não encontrado.");

    var usuario = new Usuario(nome, email, cep, endereco.Logradouro, endereco.Bairro, endereco.Localidade);

    await _repository.AdicionarAsync(usuario);
    await _repository.UnitOfWorkCommitAsync();

    return usuario;
}
}