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
    public class PessoaCadastroRepository : IPessoaCadastroRepository
    {
        private readonly BDUsuarioContext _context;
        public PessoaCadastroRepository(BDUsuarioContext bDUsuarioContext)
        {
            _context = bDUsuarioContext;            
        }

        public async Task<PessoaCadastro?> ObterPessoaCadastroAsync(string email)
        {
            return await _context.PessoaCadastro.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<PessoaCadastro> AdicionarPessoaCadastroAsync(PessoaCadastro pessoa)
        {
            var newPessoa = new PessoaCadastro() 
            {
                NomePessoa = pessoa.NomePessoa,
                Email = pessoa.Email,
                CPF = pessoa.CPF
            };

            await _context.AddAsync(newPessoa);
            await _context.SaveChangesAsync();

            return newPessoa;
        }
    }
}
