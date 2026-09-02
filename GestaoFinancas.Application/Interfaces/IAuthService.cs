using GestaoFinancas.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFinancas.Application.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponse?> LoginAsync(LoginRequest request);
    }
}
