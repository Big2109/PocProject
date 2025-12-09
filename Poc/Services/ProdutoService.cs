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

    public async Task<ProdutoModel> ObterPorGuid(Guid guidProduto)
    {
        return _mapper.Map<ProdutoModel>(await _produtoRepository.ObterPorGuid(guidProduto));
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

    public async Task<ServicoResultado> EditarProduto(ProdutoModel produto)
    {
        produto.AtualizadoEm = DateTime.Now;

        await Atualizar(produto);

        return ServicoResultado.Ok();
    }

    public async Task<ServicoResultado> DeletarProduto(Guid guidProduto)
    {
        var produto = await _produtoRepository.ObterPorGuid(guidProduto);
        if (produto is null) return ServicoResultado.Falha("Erro interno");
        await _produtoRepository.Deletar(produto);

        return ServicoResultado.Ok();
    }
}