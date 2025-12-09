using Poc.Models;

namespace Poc.Services.Interfaces;

public interface IValidacaoService
{
    Task<ServicoResultado<UsuarioModel>> ValidarNome(UsuarioModel usuario);
    Task<ServicoResultado<UsuarioModel>> ValidarNomeUsuario(UsuarioModel usuario);
    Task<ServicoResultado<UsuarioModel>> ValidarEmail(UsuarioModel usuario);
    Task<ServicoResultado<UsuarioModel>> ValidarSenha(UsuarioModel usuario);
    Task<ServicoResultado<UsuarioModel>> ValidarRegistroUsuario(UsuarioModel usuario);
}