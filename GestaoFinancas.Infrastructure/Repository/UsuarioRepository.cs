using GestaoFinancas.Domain.Entities;
using GestaoFinancas.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFinancas.Infrastructure.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public Task<Usuario?> ObterPorUsuarioAsync(string usuario)
        {
            throw new NotImplementedException();
        }
    }
}
