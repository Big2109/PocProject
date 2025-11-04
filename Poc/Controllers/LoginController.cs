using Microsoft.AspNetCore.Mvc;
using Poc.Models;
using Poc.Services.Interfaces;

namespace Poc.Controllers;

public class LoginController : Controller
{
    private readonly ILogger<LoginController> _logger;
    private readonly IUsuarioService _usuarioService;

    public LoginController(ILogger<LoginController> logger, IUsuarioService usuarioService)
    {
        _logger = logger;
        _usuarioService = usuarioService;
    }
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Registrar()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Registrar(UsuarioModel usuario)
    {
        usuario.HorarioAcesso = DateTime.Now;
        await _usuarioService.Inserir(usuario);
        return RedirectToAction("Index");
    }
}
