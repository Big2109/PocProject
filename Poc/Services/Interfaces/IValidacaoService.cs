using Poc.Models;

namespace Poc.Services.Interfaces;

public interface IValidacaoService
{
    Task<ValidacaoModel> ValidarLoginUsuario(UsuarioModel usuario);
    Task<ValidacaoModel> ValidarRegistroUsuario(UsuarioModel usuario);
}