using GestaoFinancas.Application.DTOs;
using GestaoFinancas.Application.Interfaces;
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

        public Task<LoginResponse?> LoginAsync(LoginRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
