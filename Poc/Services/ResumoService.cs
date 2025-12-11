using Poc.Models;
using Poc.Services.Interfaces;
using Poc.ViewModels;
using static Poc.Models.ResumoModel;

namespace Poc.Services;

public class ResumoService : IResumoService
{
    private readonly IUsuarioService _usuarioService;
    private readonly IProdutoService _produtoService;
    public ResumoService(IUsuarioService usuarioService,
        IProdutoService produtoService)
    {
        _usuarioService = usuarioService;
        _produtoService = produtoService;
    }

    public async Task<ResumoModel> ObterTotais()
    {
        var usuarios = await _usuarioService.Listar();
        var produtos = await _produtoService.Listar();

        return new ResumoModel(usuarios, produtos);
    }

    public async Task<ResumoViewModel> CalcularTotais()
    {
        var resumoModel = await ObterTotais();
        var usuariosPorDia = resumoModel.Usuarios
            .GroupBy(u => u.CriadoEm)
            .OrderBy(g => g.Key)
            .Select(g => new CriadosPorDia
            {
                CriadoEm = g.Key,
                Quantidade = g.Count()
            })
            .ToList();

        var produtosPorDia = resumoModel.Produtos
            .GroupBy(u => u.CriadoEm)
            .OrderBy(g => g.Key)
            .Select(g => new CriadosPorDia
            {
                CriadoEm = g.Key,
                Quantidade = g.Count()
            })
            .ToList();

        return new ResumoViewModel(usuariosPorDia, produtosPorDia);
    }
}