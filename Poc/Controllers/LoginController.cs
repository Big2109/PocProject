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
    [HttpPost]
    public async Task<IActionResult> Login(UsuarioModel usuario)
    {
        usuario.HorarioAcesso = DateTime.Now;
        var login = await _usuarioService.Login(usuario);
        if (!login.Sucesso)
        {
            Erro(login.Mensagem.FirstOrDefault() ?? "");
            return RedirectToAction("Index");
        }

        HttpContext.Session.SetString("UsuarioNome", usuario.NomeUsuario);

        return RedirectToAction("Index", "Poc");
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
}
