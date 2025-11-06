using Microsoft.AspNetCore.Mvc;
using Poc.Models;
using Poc.Services.Interfaces;

namespace Poc.Controllers;

public class LoginController : BaseController
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
        TempData.Keep();
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Login(UsuarioModel usuario)
    {
        usuario.HorarioAcesso = DateTime.Now;
        var registrar = await _usuarioService.Login(usuario);
        if (!registrar.Sucesso)
        {
            Erro(registrar.Mensagem.FirstOrDefault() ?? "");
            return View(usuario);
        }

        Sucesso("Usuário registrado com sucesso!");
        return RedirectToAction("Index");
    }
    public IActionResult Registrar()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Registrar(UsuarioModel usuario)
    {
        if (!ModelState.IsValid)
        {
            Erro(string.Empty);
            return View(usuario);
        }

        usuario.HorarioAcesso = DateTime.Now;
        var registrar = await _usuarioService.Registrar(usuario);
        if (!registrar.Sucesso)
        {
            Erro(registrar.Mensagem.FirstOrDefault() ?? "");
            return View(usuario);
        }

        Sucesso("Usuário registrado com sucesso!");
        return RedirectToAction("Index");
    }
}
