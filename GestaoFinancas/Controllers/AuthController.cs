using GestaoFinancas.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GestaoFinancas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("Auth")]
        public IActionResult Autenticar(string usuario, string senha)
        {
            var usuarioEnviado = usuario;
            var senhaEnviado = senha;

            if (usuarioEnviado == "u")
            {
                return Ok("Usuario validado com sucesso !");
            }
            else
            {
                return BadRequest("Erro ao validar usuario");
            }
        }

        [HttpGet("GetUsers")]
        public IActionResult Users() 
        {
            return Ok();        
        }

    }
}
