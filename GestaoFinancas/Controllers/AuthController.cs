using GestaoFinancas.Application.DTOs;
using GestaoFinancas.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GestaoFinancas.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(string usuario, string senha)
    {
        var loginRequest = new LoginRequest()
        {
            Usuario = usuario,
            Senha = senha
        };

        var usuarioAutenticado = await _authService.LoginAsync(loginRequest);

        var usu = usuarioAutenticado;

        return Ok(usu);
    }
}