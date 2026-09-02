using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFinancas.Domain.Entities
{
    public class PerfilUsuario
    {
        [Key]
        public int IdPerfil { get; set; }

        public string NomePerfil { get; set; }

        public bool Ativo { get; set; }
    }
}
