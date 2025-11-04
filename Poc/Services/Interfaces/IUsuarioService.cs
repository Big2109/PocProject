using Migrations.Entities;
using Poc.Models;

namespace Poc.Services.Interfaces;

public interface IUsuarioService : IBaseService<Usuario, UsuarioModel>
{
    Task<ValidacaoModel> Registrar(UsuarioModel usuario);
}