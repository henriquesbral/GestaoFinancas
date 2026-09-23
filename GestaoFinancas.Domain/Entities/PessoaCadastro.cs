using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFinancas.Domain.Entities
{
    public class PessoaCadastro
    {
        [Key]
        public int IdPessoaCadastro { get; set; }

        public string NomePessoa { get; set; }

        public string Email { get; set; }

        public string CPF { get; set; }

        public bool Ativo { get; set; }

        public DateTime DataCadastro { get; set; }
    }
}
