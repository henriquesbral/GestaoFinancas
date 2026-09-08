using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
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

        [Required, EmailAddress(ErrorMessage = "Email inválido !")]
        public string Email { get; set; }

        public string Username {  get; set; }

        public string SenhaHash { get; set; }

        [ForeignKey("PerfilUsuario")]
        public int IdPerfil { get; set; }

        public bool Ativo { get; set; }

        public DateTime DataCadastro { get; set; }

        public static string GerarUsername(string nomeCompleto)
        {
            if (string.IsNullOrWhiteSpace(nomeCompleto))
                throw new ArgumentException("Nome não pode ser vazio.", nameof(nomeCompleto));

            var partes = nomeCompleto
                .Trim()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (partes.Length == 0)
                throw new ArgumentException("Nome inválido.", nameof(nomeCompleto));

            string primeiroNome = partes[0];
            string ultimoSobrenome = partes[^1]; // último elemento do array

            // Caso a pessoa só tenha um nome (sem sobrenome)
            string username = partes.Length == 1
                ? primeiroNome
                : $"{primeiroNome}.{ultimoSobrenome}";

            return RemoverAcentos(username.ToLowerInvariant());
        }

        private static string RemoverAcentos(string texto)
        {
            var normalizado = texto.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();

            foreach (var c in normalizado)
            {
                var categoria = CharUnicodeInfo.GetUnicodeCategory(c);
                if (categoria != UnicodeCategory.NonSpacingMark)
                    sb.Append(c);
            }

            return sb.ToString().Normalize(NormalizationForm.FormC);
        }

    }
}
