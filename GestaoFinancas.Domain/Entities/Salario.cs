using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFinancas.Domain.Entities
{
    public class Salario
    {
        [Key]
        public int CodSalario { get; set; }

        public string PessoaSalario { get; set; }

        public decimal ValorSalario { get; set; }

        public DateOnly DataCadastro { get; set; }
        
        public DateTime DataAtualizacao { get; set; }
    }
}
