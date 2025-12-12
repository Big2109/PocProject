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
        var todosOsDias = await CalcularDiasDoMes();
        var totaisPorDia = await CalcularTotaisPorDia(resumoModel, todosOsDias);
        var usuariosComTodosDias = totaisPorDia.ElementAt(0).ToList();
        var produtosComTodosDias = totaisPorDia.ElementAt(1).ToList();

        return new ResumoViewModel(usuariosComTodosDias, produtosComTodosDias);
    }

    public async Task<List<DateTime>> CalcularDiasDoMes()
    {
        var ano = DateTime.Now.Year;
        var mes = DateTime.Now.Month;
        var primeiroDia = new DateTime(ano, mes, 1);
        var ultimoDia = primeiroDia.AddMonths(1).AddDays(-1);

        return Enumerable.Range(0, (ultimoDia - primeiroDia).Days + 1)
                .Select(i => primeiroDia.AddDays(i))
                .ToList();
    }

    public async Task<IEnumerable<IEnumerable<CriadosPorDia>>> CalcularTotaisPorDia(
        ResumoModel resumoModel,
        List<DateTime> todosOsDias)
    {
        var usuariosPorDia = resumoModel.Usuarios
            .GroupBy(u => u.CriadoEm.Date)
            .Select(g => new CriadosPorDia
            {
                CriadoEm = g.Key,
                Quantidade = g.Count()
            })
            .ToDictionary(c => c.CriadoEm, c => c.Quantidade);

        var usuariosComTodosDias = todosOsDias
            .Select(dia => new CriadosPorDia
            {
                CriadoEm = dia,
                Quantidade = usuariosPorDia.ContainsKey(dia) ? usuariosPorDia[dia] : 0
            })
            .ToList();

        var produtosPorDia = resumoModel.Produtos
            .GroupBy(u => u.CriadoEm.Date)
            .Select(g => new CriadosPorDia
            {
                CriadoEm = g.Key,
                Quantidade = g.Count()
            })
            .ToDictionary(c => c.CriadoEm, c => c.Quantidade);

        var produtosComTodosDias = todosOsDias
            .Select(dia => new CriadosPorDia
            {
                CriadoEm = dia,
                Quantidade = produtosPorDia.ContainsKey(dia) ? produtosPorDia[dia] : 0
            })
            .ToList();

        return new List<IEnumerable<CriadosPorDia>>
        {
            usuariosComTodosDias,
            produtosComTodosDias
        };
    }
}