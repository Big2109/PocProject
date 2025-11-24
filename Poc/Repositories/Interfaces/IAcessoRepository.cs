using Migrations.Entities;

namespace Poc.Repositories.Interfaces;

public interface IAcessoRepository : IBaseRepository<Acesso>
{
    Task<Acesso> ObterPorGuidUsuario(Guid guidUsuario);
}