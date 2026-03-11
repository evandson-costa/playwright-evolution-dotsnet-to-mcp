namespace CadastroUsuario.Domain.Entities;

public class Usuario
{
    public Guid Id { get; private set; }
    public string Nome { get; private set; }
    public string Email { get; private set; }
    public string Cep { get; private set; }
    public string Logradouro { get; private set; }
    public string Bairro { get; private set; }
    public string Cidade { get; private set; }

    // Construtor privado para garantir o uso do Factory ou métodos de criação
    private Usuario() { }

    public Usuario(string nome, string email, string cep, string logradouro, string bairro, string cidade)
    {
        Id = Guid.NewGuid();
        Nome = nome;
        Email = email;
        Cep = cep;
        Logradouro = logradouro;
        Bairro = bairro;
        Cidade = cidade;
    }
}