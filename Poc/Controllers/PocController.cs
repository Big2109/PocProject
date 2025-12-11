
using Microsoft.AspNetCore.Mvc;
using Poc.Services.Interfaces;

namespace Poc.Controllers;

public class PocController : BaseController
{
    private readonly IResumoService _resumoService;
    public PocController(ILogger<LoginController> logger,
        IResumoService resumoService) : base(logger)
    {
        _resumoService = resumoService;
    }

    public async Task<IActionResult> Index()
    {
        var resumoViewModel = await _resumoService.CalcularTotais();
        return View("Index", resumoViewModel);
    }
}