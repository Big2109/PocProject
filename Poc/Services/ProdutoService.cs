using AutoMapper;
using Poc.Models;
using Poc.Repositories.Interfaces;
using Poc.Services.Interfaces;

namespace Poc.Services;

public class ProdutoService : BaseService<Produto, ProdutoModel>, IProdutoService
{
    private readonly IProdutoRepository _produtoRepository;
    public ProdutoService(IProdutoRepository produtoRepository,
        IMapper mapper,
        IHttpContextAccessor httpContextAccessor) : base(produtoRepository, mapper, httpContextAccessor)
    {
        _produtoRepository = produtoRepository;
    }

    public async Task<ServicoResultado> CriarProduto(ProdutoModel produto)
    {
        produto.GuidProduto = Guid.NewGuid();
        produto.GuidUsuario = ObterGuidUsuario();
        produto.CriadoEm = DateTime.Now;
        produto.AtualizadoEm = DateTime.Now;

        var novo = await Inserir(produto);
        if (novo == null) return ServicoResultado.Falha("Erro interno");

        return ServicoResultado.Ok();
    }
}