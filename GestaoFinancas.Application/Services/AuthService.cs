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
        private readonly IJwtService _jwtService;

        public AuthService(
            IUsuarioRepository usuarioRepository,
            IPasswordHasher<Usuario> passwordHasher,
            IJwtService jwtService)
        {
            _usuarioRepository = usuarioRepository;
            _passwordHasher = passwordHasher;
            _jwtService = jwtService;
        }

        #region Métodos Publicos
        public async Task<LoginResponse?> LoginAsync(LoginRequest request)
        {
            var usuario = await ObterUsuarioAsync(request.Email);

            if (usuario is null)
                return null;

            if (!ValidarSenha(usuario, request.Senha))
                return null;

            return CriarRespostaAutenticacao(usuario);
        }
        #endregion

        #region Métodos Privados
        private async Task<Usuario?> ObterUsuarioAsync(string emailUsuario)
        {
            return await _usuarioRepository.ObterPorUsuarioAsync(emailUsuario);
        }

        private bool ValidarSenha(Usuario usuario, string senha)
        {
            var resultado = _passwordHasher.VerifyHashedPassword(
                usuario,
                usuario.SenhaHash,
                senha);

            return resultado != PasswordVerificationResult.Failed;
        }

        private LoginResponse CriarRespostaAutenticacao(Usuario usuario)
        {
            var resultadoJwt = _jwtService.GerarToken(usuario);

            return new LoginResponse
            {
                Token = resultadoJwt.Token,
                ExpiraEm = resultadoJwt.ExpiraEm
            };
        }
        #endregion
    }
}
