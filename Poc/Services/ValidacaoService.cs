using Poc.Enums;
using Poc.Models;
using Poc.Services.Interfaces;

namespace Poc.Services;

public class ValidacaoService : IValidacaoService
{
    public Task<ValidacaoModel> ValidarLoginUsuario(UsuarioModel usuario)
    {
        var validacao = new ValidacaoModel { Cadastro = Messages.CadastroEnum.Nulo, Mensagem = new List<string>() };

        if (string.IsNullOrEmpty(usuario.NomeUsuario))
            validacao.Mensagem.Add(Messages.PrecisaSerPreenchido("Nome Usuário"));
        else if (string.IsNullOrEmpty(usuario.Senha))
            validacao.Mensagem.Add(Messages.PrecisaSerPreenchido("Senha"));
        else
        {
            validacao.Login = Messages.LoginEnum.Ok;
            validacao.Sucesso = true;
        }

        return Task.FromResult(validacao);
    }
    public Task<ValidacaoModel> ValidarRegistroUsuario(UsuarioModel usuario)
    {
        var validacao = new ValidacaoModel { Cadastro = Messages.CadastroEnum.Nulo, Mensagem = new List<string>() };

        if (string.IsNullOrEmpty(usuario.Nome))
            validacao.Mensagem.Add(Messages.PrecisaSerPreenchido("Nome"));
        else if (string.IsNullOrEmpty(usuario.NomeUsuario))
            validacao.Mensagem.Add(Messages.PrecisaSerPreenchido("Nome Usuário"));
        else if (string.IsNullOrEmpty(usuario.Email))
            validacao.Mensagem.Add(Messages.PrecisaSerPreenchido("Email"));
        else if (string.IsNullOrEmpty(usuario.Senha))
            validacao.Mensagem.Add(Messages.PrecisaSerPreenchido("Senha"));
        else
        {
            validacao.Cadastro = Messages.CadastroEnum.Ok;
            validacao.Sucesso = true;
        }

        return Task.FromResult(validacao);
    }

}