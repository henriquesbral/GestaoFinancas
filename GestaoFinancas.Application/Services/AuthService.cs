using GestaoFinancas.Application.DTOs;
using GestaoFinancas.Application.Interfaces;
using GestaoFinancas.Domain.Entities;
using GestaoFinancas.Domain.Interfaces;
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
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IPasswordHasher<Usuario> _passwordHasher;

        public AuthService(
            IUsuarioRepository usuarioRepository,
            IPasswordHasher<Usuario> passwordHasher)
        {
            _usuarioRepository = usuarioRepository;
            _passwordHasher = passwordHasher;
        }

        #region Métodos Publicos
        public async Task<LoginResponse?> LoginAsync(LoginRequest request)
        {
            var usuario = await ObterUsuarioAsync(request.Usuario);

            if (usuario is null)
                return null;

            if (!ValidarSenha(usuario, request.Senha))
                return null;

            return await CriarRespostaAutenticacaoAsync(usuario);
        }
        #endregion

        #region Métodos Privados
        private async Task<Usuario?> ObterUsuarioAsync(string usuario)
        {
            return await _usuarioRepository
                .ObterPorUsuarioAsync(usuario);
        }

        private bool ValidarSenha(Usuario usuario, string senha)
        {
            var resultado = _passwordHasher.VerifyHashedPassword(
                usuario,
                usuario.PasswordHash,
                senha);

            return resultado != PasswordVerificationResult.Failed;
        }

        private Task<LoginResponse> CriarRespostaAutenticacaoAsync(Usuario usuario)
        {
            // JWT entrará aqui posteriormente.

            return Task.FromResult(new LoginResponse());
        }
        #endregion
    }
}
