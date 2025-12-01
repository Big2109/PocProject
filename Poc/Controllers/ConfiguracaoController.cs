using Microsoft.AspNetCore.Mvc;
using Poc.Models;
using Poc.Services.Interfaces;
using Poc.ViewModels;

namespace Poc.Controllers;

[Route("configuracao")]
public class ConfiguracaoController : BaseController
{
    private readonly IUsuarioService _usuarioService;
    public ConfiguracaoController(ILogger<ConfiguracaoController> logger, IUsuarioService usuarioService) : base(logger)
    {
        _usuarioService = usuarioService;
    }
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet("usuarios")]
    public async Task<IActionResult> Usuarios()
    {
        TempData.Keep();
        return View(new UsuariosViewModel(await _usuarioService.Listar()));
    }

    [HttpGet("novo-usuario")]
    public async Task<IActionResult> NovoUsuario()
    {
        return PartialView(new UsuariosViewModel(await _usuarioService.Listar()));
    }

    [HttpPost("novo-usuario")]
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

    [HttpPost("deletar-usuario/{guidUsuario:guid}")]
    public async Task<IActionResult> DeletarUsuario([FromRoute] Guid guidUsuario)
    {
        await _usuarioService.DeletarUsuario(guidUsuario);
        Sucesso("Usuário deletado com sucesso!");
        return RedirectToAction("Usuarios");
    }
}
