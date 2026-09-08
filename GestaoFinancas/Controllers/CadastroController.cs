using GestaoFinancas.Application.DTOs;
using GestaoFinancas.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestaoFinancas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CadastroController : ControllerBase
    {
        private readonly ICadastroService _cadastroService;
        public CadastroController(ICadastroService CadastroService)
        {
            _cadastroService = CadastroService;
        }

        [HttpPost("Cadastro")]
        public async Task<IActionResult> CadastroNewUser(CadastroRequest newUser)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            var cpfInformado = newUser.CPF.Replace(" ", "").Replace(".", "").Replace("-", "");

            if (cpfInformado.Length > 11)
            {
                return BadRequest("CPF informado é inválido");
            }

            var CadastroedUser = await _cadastroService.CadastroAsync(newUser);

            return CreatedAtAction(nameof(CadastroNewUser), new { Usuario = CadastroedUser.Usuario }, CadastroedUser);
        }
    }
}
