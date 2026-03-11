namespace CadastroUsuario.Infrastructure.Services;

using System.Net.Http.Json;
using CadastroUsuario.Domain.Interfaces;

public class ViaCepService : ICepService
{
    private readonly HttpClient _httpClient;

    public ViaCepService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<EnderecoResponse?> BuscarEnderecoPorCepAsync(string cep)
    {
        // Higienização simples do CEP
        cep = cep.Replace("-", "");
        
        var response = await _httpClient.GetAsync($"https://viacep.com.br/ws/{cep}/json/");
        
        if (!response.IsSuccessStatusCode) return null;

        return await response.Content.ReadFromJsonAsync<EnderecoResponse>();
    }
}