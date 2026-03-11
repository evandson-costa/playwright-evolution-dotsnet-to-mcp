using CadastroUsuario.Application.Services;
using CadastroUsuario.Infrastructure.Repositories;
using CadastroUsuario.Infrastructure.Services;
using CadastroUsuario.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using CadastroUsuario.Domain.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Injeção de Dependência - Seguindo Clean Code
// 1. HttpClient para o serviço de CEP externo
builder.Services.AddHttpClient<ViaCepService>();
builder.Services.AddScoped<ICepService, ViaCepService>();

// 2. Application Service (Onde reside a regra de negócio)
builder.Services.AddScoped<UsuarioAppService>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();


// Busca a string de conexão do appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();


// 3. Configuração de CORS (Essencial para o seu Front-end em Vite rodar)
builder.Services.AddCors(options =>
{
    options.AddPolicy("Default", policy => 
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("Default");
app.UseAuthorization();
app.MapControllers();

app.Run();