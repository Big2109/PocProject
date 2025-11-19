using Migrations.Entities;

namespace Poc.Repositories.Interfaces;

public interface IUsuarioRepository : IBaseRepository<Usuario>
{
    Task<Usuario> ObterPorNomeUsuario(string nomeUsuario);
    Task<Usuario> ObterPorNomeUsuarioESenha(Usuario usuario);
}