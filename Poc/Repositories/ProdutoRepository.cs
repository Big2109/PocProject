using Microsoft.EntityFrameworkCore;
using Migrations.Context;
using Poc.Repositories.Interfaces;
namespace Poc.Repositories;

public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
{
    public ProdutoRepository(Context context) : base(context) { }

    public async Task<Produto> ObterPorGuid(Guid guidProduto)
    {
        return await _context.Produto
            .Where(u => u.GuidProduto == guidProduto).FirstOrDefaultAsync();
    }
}