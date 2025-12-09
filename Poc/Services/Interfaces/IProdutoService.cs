using Migrations.Entities;
using Poc.Models;

namespace Poc.Services.Interfaces;

public interface IProdutoService : IBaseService<Produto, ProdutoModel>
{
    Task<ServicoResultado> CriarProduto(ProdutoModel produto);
}