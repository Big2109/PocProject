using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Poc.Models;
using Poc.Services.Interfaces;

namespace Poc.Controllers;

public class HomeController : BaseController
{
    private readonly IClienteService _clienteService;
    public HomeController(ILogger<HomeController> logger, IClienteService clienteService) : base(logger)
    {
        _clienteService = clienteService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [Route("clientes/listar")]
    public async Task<IActionResult> ListarClientes()
    {
        return Ok(await _clienteService.Listar());
    }
    [HttpPost, Route("clientes/inserir")]
    public async Task<IActionResult> InserirCliente([FromBody] ClienteModel cliente)
    {
        return Ok(await _clienteService.Inserir(cliente));
    }
}
