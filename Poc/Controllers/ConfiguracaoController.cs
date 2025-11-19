using Microsoft.AspNetCore.Mvc;
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
}
