using Migrations.Entities;

namespace Poc.Repositories.Interfaces;

public interface IUsuarioRepository : IBaseRepository<Usuario>
{
    Task<Usuario> ObterLogin(Usuario usuario);
}