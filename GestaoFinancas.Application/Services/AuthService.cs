using GestaoFinancas.Application.Interfaces.IServices;
using GestaoFinancas.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFinancas.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IPasswordHasher<Usuario> _passwordHasher;
        public AuthService(IPasswordHasher<Usuario> passwordHasher)
        {
            _passwordHasher = passwordHasher;
        }

        public async Task<bool> IsAuthenticated(string usuario, string senha)
        {
            bool autenticado = false;

            autenticado = await AutenticarUsuario();

            return autenticado;
        }

        private async Task<bool> AutenticarUsuario()
        {
            return false;
        } 
    }
}
