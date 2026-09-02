using GestaoFinancas.Application.Interfaces;
using GestaoFinancas.Application.Services;
using GestaoFinancas.Domain.Entities;
using GestaoFinancas.Domain.Interfaces;
using GestaoFinancas.Infrastructure.Data;
using GestaoFinancas.Infrastructure.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Registra os serviços necessários para Controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Banco da aplicação
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));

// Banco de usuários
builder.Services.AddDbContext<BDUsuarioContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("BDUsuariosFinanceiro")
    ));

// Repository
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

// Auth Service
builder.Services.AddScoped<IAuthService, AuthService>();

// Password Hasher
builder.Services.AddScoped<IPasswordHasher<Usuario>, PasswordHasher<Usuario>>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();