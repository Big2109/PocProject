using Microsoft.EntityFrameworkCore;
using Migrations.Context;
using Migrations.Entities;
using Poc.Repositories.Interfaces;
namespace Poc.Repositories;

public class AcessoRepository : BaseRepository<Acesso>, IAcessoRepository
{
    public AcessoRepository(Context context) : base(context) { }

    public async Task<Acesso> ObterPorGuidUsuario(Guid guidUsuario)
    {
        return await _context.Acesso
            .AsNoTracking()
            .Where(u => u.GuidUsuario == guidUsuario)
            .FirstOrDefaultAsync();
    }
}