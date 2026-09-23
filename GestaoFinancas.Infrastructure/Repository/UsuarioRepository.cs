using GestaoFinancas.Domain.Entities;
using GestaoFinancas.Domain.Enums;
using GestaoFinancas.Domain.Interfaces;
using GestaoFinancas.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace GestaoFinancas.Infrastructure.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly BDUsuarioContext _context;
        private readonly IPasswordHasher<Usuario> _passwordHasher;
        public UsuarioRepository(BDUsuarioContext context, IPasswordHasher<Usuario> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public async Task<Usuario?> ObterPorUsuarioAsync(string emailUsuario)
        {
            return await _context.Usuario.FirstOrDefaultAsync(x => x.Email == emailUsuario);
        }

        public async Task<Usuario> AdicionarUsuarioAsync(Usuario usuario)
        {
            var newUser = new Usuario()
            {
                Email = usuario.Email,
                Username = usuario.Username,
                SenhaHash = _passwordHasher.HashPassword(usuario, usuario.SenhaHash),
                IdPerfil = usuario.IdPerfil,
                IdPessoaCadastro = usuario.IdPessoaCadastro,
                Ativo = usuario.Ativo,
                DataCadastro = usuario.DataCadastro
            };

            _context.Usuario.Add(newUser);
            _context.SaveChanges();

            return _context.Usuario.FirstOrDefault(u => u.Email == newUser.Email);
        }
    }
}