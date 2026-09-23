using GestaoFinancas.Application.DTOs;
using GestaoFinancas.Application.Interfaces;
using GestaoFinancas.Domain.Entities;
using GestaoFinancas.Domain.Enums;
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
            var novaPessoa = new PessoaCadastro()
            {
                NomePessoa = request.Nome,
                CPF = request.CPF.Replace(" ","").Replace(".", "").Replace("-", ""),
                Email = request.Email,
                Ativo = true,
                DataCadastro = DateTime.Now
            };

            var salvarNovaPessoa = _PessoaCadastroRepository.AdicionarPessoaCadastroAsync(novaPessoa);

            if (salvarNovaPessoa is not null && salvarNovaPessoa.Result.IdPessoaCadastro != 0)
            {
                var novoUsername = Usuario.GerarUsername(novaPessoa.NomePessoa);
                var usuario = new Usuario()
                {
                    Email = novaPessoa.Email,
                    Username = novoUsername,
                    SenhaHash = "Teste",
                    IdPerfil = (int)PerfilUsuarioEnum.Usuario,
                    IdPessoaCadastro = salvarNovaPessoa.Result.IdPessoaCadastro,
                    Ativo = true,
                    DataCadastro = DateTime.Now
                };

                var novoUsuario = _usuarioRepository.AdicionarUsuarioAsync(usuario);

                var retorno = new CadastroResponse();
                retorno.Usuario = novoUsuario.Result.Username;
                retorno.Senha = usuario.SenhaHash;

                return retorno;
            }
            else
            {
                return null;
            }
        }
    }
}
