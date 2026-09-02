using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFinancas.Domain.Entities
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("PessoaCadastro")]
        public int IdPessoaCadastro { get; set; }

        public string User {  get; set; }

        public string PasswordHash { get; set; }

        [ForeignKey("PerfilUsuario")]
        public int IdPerfil { get; set; }

        public DateTime DataCadastro { get; set; }

    }
}
