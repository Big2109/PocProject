using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Poc.Models;
using Poc.Services.Interfaces;

namespace Poc.Controllers;

public class LoginController : BaseController
{
    private readonly IUsuarioService _usuarioService;
    public LoginController(ILogger<LoginController> logger, IUsuarioService usuarioService) : base(logger)
    {
        _usuarioService = usuarioService;
    }
    public IActionResult Index()
    {
        TempData["Exibir"] = false;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Entrar(UsuarioModel usuario)
    {
        usuario.HorarioAcesso = DateTime.Now;
        var login = await _usuarioService.Login(usuario);
        if (!login.Sucesso)
        {
            Erro(login.Erros.FirstOrDefault() ?? "");
            return RedirectToAction("Index");
        }

        return RedirectToAction("Dashboard", "Poc");
    }
    public IActionResult Registrar()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Registrar(UsuarioModel novoUsuario)
    {
        if (!ModelState.IsValid)
        {
            Erro(string.Empty);
            return View(novoUsuario);
        }

        novoUsuario.CriadoEm = DateTime.Now;
        novoUsuario.HorarioAcesso = DateTime.Now;
        var registrar = await _usuarioService.Registrar(novoUsuario);
        if (!registrar.Sucesso)
        {
            Erro(registrar.Erros.FirstOrDefault() ?? "");
            return RedirectToAction("Registrar");
        }

        Sucesso("Usuário registrado com sucesso!");
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Sair()
    {
        await HttpContext.SignOutAsync("CookieAuthentication");
        return RedirectToAction("Index", "Home");
    }
}
