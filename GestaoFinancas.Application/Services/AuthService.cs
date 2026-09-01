using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFinancas.Application.Services
{
    public class AuthService
    {
        private readonly AppContext _context;
        public AuthService(AppContext context)
        {
            _context = context;
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
