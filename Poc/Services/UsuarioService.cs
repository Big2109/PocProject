using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Migrations.Entities;
using Poc.Models;
using Poc.Repositories.Interfaces;
using Poc.Services.Interfaces;

namespace Poc.Services;

public class UsuarioService : BaseService<Usuario, UsuarioModel>, IUsuarioService
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IValidacaoService _validacaoService;
    private readonly IAcessoService _acessoService;
    public UsuarioService(IUsuarioRepository usuarioRepository,
        IMapper mapper,
        IValidacaoService validacaoService,
        IAcessoService acessoService,
        IHttpContextAccessor httpContextAccessor) : base(usuarioRepository, mapper, httpContextAccessor)
    {
        _usuarioRepository = usuarioRepository;
        _validacaoService = validacaoService;
        _acessoService = acessoService;
    }
    public async Task<ServicoResultado<UsuarioModel>> Login(UsuarioModel usuario)
    {
        var nomeUsuario = await _validacaoService.ValidarNomeUsuario(usuario);
        if (!nomeUsuario.Sucesso) return nomeUsuario;

        var senha = await _validacaoService.ValidarSenha(usuario);
        if (!senha.Sucesso) return senha;

        var login = await _usuarioRepository.ObterPorNomeUsuarioESenha(_mapper.Map<Usuario>(usuario));
        if (login is null) return ServicoResultado<UsuarioModel>.Falha("Senha ou usuário incorreto(s).");

        if (!login.Ativo) return ServicoResultado<UsuarioModel>.Falha("Usuário inativo.");

        var acesso = new AcessoModel
        {
            GuidAcesso = Guid.NewGuid(),
            GuidUsuario = login.GuidUsuario,
            HorarioAcesso = DateTime.Now
        };

        await _acessoService.Inserir(acesso);

        var claims = new List<Claim>
            {
                new Claim("Nome", login.Nome),
                new Claim(ClaimTypes.Name, login.NomeUsuario),
                new Claim("GuidUsuario", login.GuidUsuario.ToString())
            };

        var claimsIdentity = new ClaimsIdentity(claims, "CookieAuthentication");
        var principal = new ClaimsPrincipal(claimsIdentity);
        var context = _httpContextAccessor.HttpContext;
        if (context == null) throw new InvalidOperationException("HttpContext não está disponível");

        await context.SignInAsync(
            "CookieAuthentication",
            principal,
            new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = DateTime.UtcNow.AddHours(8)
            });

        var mapped = _mapper.Map<UsuarioModel>(login);
        return ServicoResultado<UsuarioModel>.Ok(mapped);
    }
    public async Task<ServicoResultado<UsuarioModel>> Registrar(UsuarioModel novoUsuario)
    {
        var validar = await _validacaoService.ValidarRegistroUsuario(novoUsuario);
        if (!validar.Sucesso) return validar;

        var nomeUsuario = await _usuarioRepository.ObterPorNomeUsuario(_mapper.Map<Usuario>(novoUsuario));
        if (nomeUsuario is not null) return ServicoResultado<UsuarioModel>.Falha("Nome de usuário já em uso.");

        var novo = await Inserir(novoUsuario);

        await _acessoService.Inserir(new AcessoModel
        {
            GuidUsuario = novo.GuidUsuario,
            HorarioAcesso = DateTime.Now
        });

        return ServicoResultado<UsuarioModel>.Ok(novo);
    }

    public async Task<ServicoResultado> InativarUsuario(Guid guidUsuario)
    {
        var usuario = await _usuarioRepository.ObterPorGuid(guidUsuario);
        if (usuario is null) return ServicoResultado.Falha("Erro ao obter acesso");

        usuario.Ativo = false;
        await _usuarioRepository.Atualizar(usuario);

        return ServicoResultado.Ok();
    }
    public async Task<ServicoResultado> DeletarUsuario(Guid guidUsuario)
    {
        var acesso = await _acessoService.ObterPorGuidUsuario(guidUsuario);
        if (acesso is null) return ServicoResultado.Falha("Erro ao obter acesso");
        await _acessoService.Deletar(acesso);

        var usuario = await _usuarioRepository.ObterPorGuid(guidUsuario);
        if (usuario is null) return ServicoResultado.Falha("Erro ao obter usuário");
        await _usuarioRepository.Deletar(usuario);

        return ServicoResultado.Ok();
    }
}