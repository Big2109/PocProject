using Poc.Enums;
using Poc.Models;
using Poc.Services.Interfaces;

namespace Poc.Services;

public class ValidacaoService : IValidacaoService
{

    public async Task<ServicoResultado<UsuarioModel>> ValidarNome(UsuarioModel usuario)
    {
        if (string.IsNullOrEmpty(usuario.Nome))
            return ServicoResultado<UsuarioModel>.Falha(Messages.PrecisaSerPreenchido("Nome"));

        return ServicoResultado<UsuarioModel>.Ok(usuario);
    }
    public async Task<ServicoResultado<UsuarioModel>> ValidarNomeUsuario(UsuarioModel usuario)
    {
        if (string.IsNullOrEmpty(usuario.NomeUsuario))
            return ServicoResultado<UsuarioModel>.Falha(Messages.PrecisaSerPreenchido("Nome do usuário"));

        return ServicoResultado<UsuarioModel>.Ok(usuario);
    }
    public async Task<ServicoResultado<UsuarioModel>> ValidarEmail(UsuarioModel usuario)
    {
        if (string.IsNullOrEmpty(usuario.Email))
            return ServicoResultado<UsuarioModel>.Falha(Messages.PrecisaSerPreenchido("Email"));

        return ServicoResultado<UsuarioModel>.Ok(usuario);
    }
    public async Task<ServicoResultado<UsuarioModel>> ValidarSenha(UsuarioModel usuario)
    {
        if (string.IsNullOrEmpty(usuario.Senha))
            return ServicoResultado<UsuarioModel>.Falha(Messages.PrecisaSerPreenchido("Senha"));

        return ServicoResultado<UsuarioModel>.Ok(usuario);
    }
    public async Task<ServicoResultado<UsuarioModel>> ValidarRegistroUsuario(UsuarioModel usuario)
    {
        var erros = new List<string>();

        var nome = await ValidarNome(usuario);
        if (!nome.Sucesso) erros.Add(nome.Erros.FirstOrDefault() ?? "");

        var nomeUsuario = await ValidarNomeUsuario(usuario);
        if (!nomeUsuario.Sucesso) erros.Add(nomeUsuario.Erros.FirstOrDefault() ?? "");

        var email = await ValidarEmail(usuario);
        if (!email.Sucesso) erros.Add(email.Erros.FirstOrDefault() ?? "");

        var senha = await ValidarSenha(usuario);
        if (!senha.Sucesso) erros.Add(senha.Erros.FirstOrDefault() ?? "");

        if (erros.Any()) return ServicoResultado<UsuarioModel>.Falha(erros);

        return ServicoResultado<UsuarioModel>.Ok(usuario);
    }
}