using Microsoft.AspNetCore.Mvc;
using Poc.Models;
using Poc.Services.Interfaces;
using Poc.ViewModels;

namespace Poc.Controllers;

public class ConfiguracaoController : BaseController
{
    private readonly IUsuarioService _usuarioService;
    public ConfiguracaoController(ILogger<ConfiguracaoController> logger, IUsuarioService usuarioService) : base(logger)
    {
        _usuarioService = usuarioService;
    }
    public IActionResult Index()
    {
        TempData.Keep();
        return View();
    }

    public async Task<IActionResult> Usuarios()
    {
        return View(new UsuariosViewModel(await _usuarioService.Listar()));
    }

    public async Task<IActionResult> NovoUsuario()
    {
        return View(new UsuariosViewModel(await _usuarioService.Listar()));
    }

    [HttpPost]
    public async Task<IActionResult> NovoUsuario(UsuarioModel novoUsuario)
    {
        if (!ModelState.IsValid) Erro(string.Empty);

        else
        {
            novoUsuario.CriadoEm = DateTime.Now;
            novoUsuario.HorarioAcesso = DateTime.Now;
            var registrar = await _usuarioService.Registrar(novoUsuario);
            if (!registrar.Sucesso)
            {
                Erro(registrar.Mensagem.FirstOrDefault() ?? "");
                return View(novoUsuario);
            }

            Sucesso("Novo Usuário registrado com sucesso!");
        }

        return RedirectToAction("Usuarios");
    }

    [HttpPost, Route("deletar-usuario")]
    public async Task<IActionResult> DeletarUsuario(Guid guidUsuario)
    {
        return RedirectToAction("Usuarios");
    }
}
