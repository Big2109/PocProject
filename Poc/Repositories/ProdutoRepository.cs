using Migrations.Context;
using Migrations.Entities;
using Poc.Repositories.Interfaces;
namespace Poc.Repositories;

public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
{
    public ProdutoRepository(Context context) : base(context) { }
}