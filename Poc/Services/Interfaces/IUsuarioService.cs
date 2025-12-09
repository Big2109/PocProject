using Migrations.Entities;
using Poc.Models;

namespace Poc.Services.Interfaces;

public interface IUsuarioService : IBaseService<Usuario, UsuarioModel>
{
    Task<ServicoResultado<UsuarioModel>> Login(UsuarioModel usuario);
    Task<ServicoResultado<UsuarioModel>> Registrar(UsuarioModel usuario);
    Task<ServicoResultado> DeletarUsuario(Guid guidUsuario);
}