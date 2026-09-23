using GestaoFinancas.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFinancas.Application.Interfaces
{
    public interface ICadastroService
    {
        Task<CadastroResponse?> CadastroAsync(CadastroRequest request);
    }
}
