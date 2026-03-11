namespace CadastroUsuario.Domain.Interfaces;

public interface ICepService
{
    Task<EnderecoResponse?> BuscarEnderecoPorCepAsync(string cep);
}

public record EnderecoResponse(
    string Cep, 
    string Logradouro, 
    string Bairro, 
    string Localidade, 
    string Uf);