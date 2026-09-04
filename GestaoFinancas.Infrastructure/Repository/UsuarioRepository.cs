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
        public UsuarioRepository(BDUsuarioContext context)
        {
            _context = context;
        }

        public async Task<Usuario?> ObterPorUsuarioAsync(string usuario)
        {
            return await _context.Usuario.FirstOrDefaultAsync(x => x.User == usuario);
        }

        public async Task AdicionarUsuarioAsync(Usuario usuario)
        {
            var newUser = new Usuario()
            {
                User = usuario.User,
                PasswordHash = _passwordHasher.HashPassword(usuario, usuario.PasswordHash),
                IdPerfil = (int)PerfilUsuarioEnum.Usuario
            };

            await _context.Usuario.AddAsync(newUser);
            await _context.SaveChangesAsync();
        }
    }
}
