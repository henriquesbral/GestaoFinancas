using GestaoFinancas.Application.Interfaces;
using GestaoFinancas.Application.Services;
using GestaoFinancas.Domain.Entities;
using GestaoFinancas.Domain.Interfaces;
using GestaoFinancas.Infrastructure.Data;
using GestaoFinancas.Infrastructure.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var DefaultConnection = builder.Configuration.GetConnectionString(
    "BDUsuariosFinanceiro")
    ?? throw new InvalidOperationException("Connection string não encontrada.");
var BDUserConnectionString = builder.Configuration.GetConnectionString(
    "BDUsuariosFinanceiro")
    ?? throw new InvalidOperationException("Connection string não encontrada.");
var jwtKey = builder.Configuration["Jwt:Key"];
var jwtIssuer = builder.Configuration["Jwt:Issuer"];
var jwtAudience = builder.Configuration["Jwt:Audience"];

if (string.IsNullOrWhiteSpace(jwtKey))
    throw new InvalidOperationException("Jwt:Key não configurada.");

// Registra os serviços necessários para Controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Banco da aplicação
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(DefaultConnection));

// Banco de usuários
builder.Services.AddDbContext<BDUsuarioContext>(options =>
    options.UseSqlServer(BDUserConnectionString));

// Repository
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IPessoaCadastroRepository, PessoaCadastroRepository>();

// Auth Service
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ICadastroService, CadastroService>();
builder.Services.AddScoped<IJwtService, JwtService>();

// Password Hasher
builder.Services.AddScoped<IPasswordHasher<Usuario>, PasswordHasher<Usuario>>();

// Proccess Authorization
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = jwtIssuer,

            ValidateAudience = true,
            ValidAudience = jwtAudience,

            ValidateIssuerSigningKey = true,
            IssuerSigningKey =
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(jwtKey)),

            ValidateLifetime = true
        };
    });

builder.Services.AddAuthorization();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();