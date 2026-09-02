using GestaoFinancas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFinancas.Infrastructure.Data
{
    public class BDUsuarioContext : DbContext
    {
        public BDUsuarioContext(DbContextOptions<BDUsuarioContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuario {  get; set; }
        
        public DbSet<PerfilUsuario> PerfilUsuario {  get; set; }

        public DbSet<PessoaCadastro> PessoaCadastro {  get; set; }


    }
}
