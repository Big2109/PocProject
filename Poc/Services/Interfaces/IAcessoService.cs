using Migrations.Entities;
using Poc.Models;

namespace Poc.Services.Interfaces;

public interface IAcessoService : IBaseService<Acesso, AcessoModel>
{
    Task<AcessoModel> ObterPorGuidUsuario(Guid guidUsuario);
}