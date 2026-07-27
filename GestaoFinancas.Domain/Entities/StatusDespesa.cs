using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFinancas.Domain.Entities
{
    public class StatusDespesa
    {
        [Key]
        public int CodStatusDespesa { get; set; }

        public string NomeStatusDespesa { get; set; }
    }
}
