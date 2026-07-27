using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFinancas.Domain.Entities
{
    public class Dividas
    {
        [Key]
        public int CodDividas { get; set; }

        public string NomeDivida { get; set; }

        public decimal ValorDivida { get; set; }

        [ForeignKey("DespesaFixa")]
        public int CodDespesaFixa { get; set; }

        [ForeignKey("DespesaParcelada")]
        public int CodDespesaParcelada { get; set; }

        [ForeignKey("TipoRotatividade")]
        public int CodTipoRotatividade { get; set; }

        [ForeignKey("ResponsavelDivida")]
        public int CodResponsavelDivida { get; set; }

        [ForeignKey("StatusDespesa")]
        public int CodStatusDespesa { get; set; }

        public bool Ativo { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime DataPagamento { get; set; }
    }
}
