using GestaoFinancas.Application.DTOs;
using GestaoFinancas.Application.Interfaces;
using GestaoFinancas.Domain.Entities;
using GestaoFinancas.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFinancas.Application.Services
{
    public class CadastroService : ICadastroService
    {
        private readonly IPessoaCadastroRepository _PessoaCadastroRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        const string caracteresPermitidos = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        
        public CadastroService(IPessoaCadastroRepository PessoaCadastroRepository, IUsuarioRepository usuarioRepository)
        {
            _PessoaCadastroRepository = PessoaCadastroRepository;
            _usuarioRepository = usuarioRepository;
        }
        public async Task<CadastroResponse?> CadastroAsync(CadastroRequest request)
        {
            var novoUsuario = new PessoaCadastro()
            {
                NomePessoa = request.Nome,
                CPF = request.CPF,
                Email = request.Email

            };

            var salvarNovoUsuario = _PessoaCadastroRepository.AdicionarPessoaCadastroAsync(novoUsuario);

            if (salvarNovoUsuario is not null && salvarNovoUsuario.Id != 0)
            {
                var usuario = new Usuario()
                {
                    User = "carlos.sobral",
                    PasswordHash = "*"
                };
                var salvar = _usuarioRepository.AdicionarUsuarioAsync(usuario);
                return new CadastroResponse()
                {
                    Usuario = usuario.User,
                    Senha = RandomNumberGenerator.GetString(caracteresPermitidos, 10)
                };
            }
            else
            {
                return null;
            }
        }
    }
}
