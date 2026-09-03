using GestaoFinancas.Domain.Entities;
using GestaoFinancas.Domain.Interfaces;
using GestaoFinancas.Infrastructure.Data;
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
        public UsuarioRepository(BDUsuarioContext context)
        {
            _context = context;
        }
        public async Task<Usuario?> ObterPorUsuarioAsync(string usuario)
        {
            try
            {
                var connectionString = _context.Database.GetDbConnection().ConnectionString;

                await using var connection = new SqlConnection(connectionString);
                await connection.OpenAsync(CancellationToken.None);

                Console.WriteLine($"Conectado a: {connection.DataSource}");

                return await _context.Usuario
                    .FirstOrDefaultAsync(x => x.User == usuario);
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL {ex.Number}: {ex.Message}");
                Console.WriteLine(ex.ToString());
                throw;
            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine($"Abertura da conexão cancelada: {ex.Message}");
                Console.WriteLine(ex.ToString());
                throw;
            }
        }
    }
}
