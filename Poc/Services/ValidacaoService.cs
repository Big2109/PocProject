using Poc.Models;
using Poc.Services.Interfaces;

namespace Poc.Services;

public class ValidacaoService : IValidacaoService
{
    public async Task<ValidacaoModel> ValidarRegistroUsuario(UsuarioModel usuario)
    {
        var validacao = new ValidacaoModel();
        return validacao;
    }
}