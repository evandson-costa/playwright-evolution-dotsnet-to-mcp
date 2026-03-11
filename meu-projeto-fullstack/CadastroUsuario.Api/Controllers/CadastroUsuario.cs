using Microsoft.AspNetCore.Mvc;
using CadastroUsuario.Application.Services;
using CadastroUsuario.Domain.Interfaces;

namespace CadastroUsuario.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuariosController : ControllerBase
{
    private readonly UsuarioAppService _usuarioService;

    public UsuariosController(UsuarioAppService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpPost]
    public async Task<IActionResult> Cadastrar([FromBody] CreateUsuarioRequest request)
    {
        try 
        {
            var usuario = await _usuarioService.CriarUsuarioComCepAsync(
                request.Nome, 
                request.Email, 
                request.Cep);

            return Ok(usuario);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpGet("cep/{cep}")]
    public async Task<IActionResult> BuscarCep([FromServices] ICepService cepService, string cep)
    {
        var endereco = await cepService.BuscarEnderecoPorCepAsync(cep);
        if (endereco == null) return NotFound();
        return Ok(endereco);
    }
}

public record CreateUsuarioRequest(string Nome, string Email, string Cep);