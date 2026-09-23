using GestaoFinancas.Application.Interfaces;
using GestaoFinancas.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFinancas.Application.Services
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _configuration;
        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public (string Token, DateTime ExpiraEm) GerarToken(Usuario usuario)
        {
            var chave = _configuration["Jwt:Key"];
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];
            var expirationMinutes = int.Parse(_configuration.GetSection("JwtSettings:ExpireMinutes").Value);
            
            if (string.IsNullOrWhiteSpace(chave))
                throw new InvalidOperationException("Chave JWT não configurada.");

            if (string.IsNullOrWhiteSpace(issuer))
                throw new InvalidOperationException("Issuer JWT não configurado.");

            if (string.IsNullOrWhiteSpace(audience))
                throw new InvalidOperationException("Audience JWT não configurado.");

            var expiraEm = DateTime.UtcNow.AddMinutes(expirationMinutes);

            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Sub, usuario.Id.ToString()),
                new(JwtRegisteredClaimNames.Email, usuario.Email),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var chaveSeguranca =
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(chave));

            var credenciais =
                new SigningCredentials(
                    chaveSeguranca,
                    SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: expiraEm,
                signingCredentials: credenciais);

            var tokenString =
                new JwtSecurityTokenHandler()
                    .WriteToken(token);

            return (tokenString, expiraEm);

        }
    }
}
