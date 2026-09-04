using GestaoFinancas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFinancas.Domain.Interfaces
{
    public interface IPessoaCadastroRepository
    {
        Task<PessoaCadastro?> ObterPessoaCadastroAsync(string email);

        Task<PessoaCadastro> AdicionarPessoaCadastroAsync(PessoaCadastro pessoa);
    }
}
