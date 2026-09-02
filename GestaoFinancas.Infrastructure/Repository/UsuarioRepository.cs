using GestaoFinancas.Domain.Entities;
using GestaoFinancas.Domain.Interfaces;
using GestaoFinancas.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFinancas.Infrastructure.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly BDUsuarioContext _context;
        public UsuarioRepository(BDUsuarioContext context)
        {
            _context = context;
        }
        public async Task<Usuario?> ObterPorUsuarioAsync(string usuario)
        {
            return await _context.Usuario.FirstOrDefaultAsync(x => x.User == usuario);
        }
    }
}
