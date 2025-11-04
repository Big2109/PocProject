using Poc.Models;

namespace Poc.Services.Interfaces;

public interface IValidacaoService
{
    Task<ValidacaoModel> ValidarRegistroUsuario(UsuarioModel usuario);
}