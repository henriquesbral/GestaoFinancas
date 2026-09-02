using GestaoFinancas.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFinancas.Application.Services
{
    public class AuthService : IAuthService
    {
        public AuthService()
        {
            
        }

        public async Task<bool> IsAuthenticated(string usuario, string senha)
        {
            bool autenticado = false;

            autenticado = await AutenticarUsuario();

            return autenticado;
        }

        private async Task<bool> AutenticarUsuario()
        {
            return false;
        } 
    }
}
