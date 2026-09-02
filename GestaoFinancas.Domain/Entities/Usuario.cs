using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFinancas.Domain.Entities
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        public string User {  get; set; }

        public string PasswordHash { get; set; }

    }
}
