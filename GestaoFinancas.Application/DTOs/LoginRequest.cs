using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFinancas.Application.DTOs
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "Usuário é obrigatório !")]
        public string Usuario { get; set; } = string.Empty;

        [Required(ErrorMessage = "A senha é obrigatória !")]
        public string Senha { get; set; } = string.Empty;
    }
}
