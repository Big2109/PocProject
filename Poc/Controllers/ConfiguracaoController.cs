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
        return View("Usuarios", new UsuariosViewModel(await _usuarioService.Listar()));
    }

    [HttpGet("novo-usuario")]
    public async Task<IActionResult> NovoUsuario()
    {
        TempData["NovoUsuario"] = true;
        return await Usuarios();
    }

    [HttpPost("novo-usuario")]
    public async Task<IActionResult> NovoUsuario(UsuarioModel novoUsuario)
    {
        if (!ModelState.IsValid)
        {
            Erro(string.Empty);
            return await Usuarios();
        }

        else
        {
            novoUsuario.CriadoEm = DateTime.Now;
            novoUsuario.HorarioAcesso = DateTime.Now;
            var registrar = await _usuarioService.Registrar(novoUsuario);
            if (!registrar.Sucesso)
            {
                Erro(registrar.Erros.FirstOrDefault() ?? "");
                return View(novoUsuario);
            }

            Sucesso("Novo Usuário registrado com sucesso!");
        }

        return RedirectToAction("Usuarios");
    }

    [HttpPost("inativar-usuario/{guidUsuario:guid}")]
    public async Task<IActionResult> InativarUsuario([FromRoute] Guid guidUsuario)
    {
        var inativado = await _usuarioService.InativarUsuario(guidUsuario);
        if (!inativado.Sucesso) Erro(inativado.Erros.FirstOrDefault() ?? "");
        else Sucesso("Usuário inativado com sucesso!");
        return await Usuarios();
    }

    [HttpPost("deletar-usuario/{guidUsuario:guid}")]
    public async Task<IActionResult> DeletarUsuario([FromRoute] Guid guidUsuario)
    {
        var deletado = await _usuarioService.DeletarUsuario(guidUsuario);
        if (!deletado.Sucesso) Erro(deletado.Erros.FirstOrDefault() ?? "");
        else Sucesso("Usuário deletado com sucesso!");
        return await Usuarios();
    }
}
