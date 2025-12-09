using Migrations.Entities;

namespace Poc.Repositories.Interfaces;

public interface IUsuarioRepository : IBaseRepository<Usuario>
{
    Task<Usuario> ObterPorId(Guid guidUsuario);
    Task<Usuario> ObterPorNomeUsuario(Usuario usuario);
    Task<Usuario> ObterPorNomeUsuarioESenha(Usuario usuario);
}