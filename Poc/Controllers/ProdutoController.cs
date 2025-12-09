using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Poc.Services.Interfaces;
using Poc.ViewModels;

namespace Poc.Controllers;

public class ProdutoController : BaseController
{
    private readonly IProdutoService _produtoService;
    public ProdutoController(ILogger<LoginController> logger, IProdutoService produtoService) : base(logger)
    {
        _produtoService = produtoService;
    }

    public async Task<IActionResult> Index()
    {
        var model = await _produtoService.Listar();
        return View(new ProdutosViewModel(model));
    }
    public async Task<IActionResult> CriarProduto()
    {
        return View(new ProdutoModel());
    }

    [HttpPost]
    public async Task<IActionResult> CriarProduto([FromForm] ProdutoModel produto)
    {
        if (!ModelState.IsValid)
        {
            Erro(string.Empty);
            return RedirectToAction("CriarProduto");
        }

        var novo = await _produtoService.CriarProduto(produto);
        if (!novo.Sucesso) Erro(novo.Erros.FirstOrDefault() ?? "");

        Sucesso($"Novo produto criado com sucesso!");
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> EditarProduto(Guid guidProduto)
    {
        var model = await _produtoService.ObterPorGuid(guidProduto);
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> EditarProduto([FromForm] ProdutoModel produto)
    {
        if (!ModelState.IsValid)
        {
            Erro(string.Empty);
            return RedirectToAction("EditarProduto");
        }

        var editado = await _produtoService.EditarProduto(produto);
        if (!editado.Sucesso) Erro(editado.Erros.FirstOrDefault() ?? "");
        else Sucesso($"Produto atualizado com sucesso!");

        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> DeletarProduto([FromQuery] Guid guidProduto)
    {
        var deletado = await _produtoService.DeletarProduto(guidProduto);
        if (!deletado.Sucesso) Erro(deletado.Erros.FirstOrDefault() ?? "");
        else Sucesso("Produto deletado com sucesso!");

        return RedirectToAction("Index");
    }
}