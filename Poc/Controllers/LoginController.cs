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
        TempData.Keep();
        return View();
    }

    public async Task<IActionResult> IsLogged()
    {
        if (User.Identity == null)
        {
            Erro("User identity nulo.");
            return RedirectToAction("Index");
        }

        return Ok(new
        {
            isLogged = User.Identity.IsAuthenticated,
            userName = User.Identity.Name ?? ""
        });
    }

    [HttpPost]
    public async Task<IActionResult> Entrar(UsuarioModel usuario)
    {
        usuario.HorarioAcesso = DateTime.Now;
        var login = await _usuarioService.Login(usuario);
        if (!login.Sucesso)
        {
            Erro(login.Mensagem.FirstOrDefault() ?? "");
            return RedirectToAction("Index");
        }

        HttpContext.Session.SetString("NomeUsuario", usuario.NomeUsuario);

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
            Erro(registrar.Mensagem.FirstOrDefault() ?? "");
            return View(novoUsuario);
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
