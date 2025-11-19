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
    private readonly IHttpContextAccessor _httpContextAccessor;
    public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper, IValidacaoService validacaoService, IAcessoService acessoService, IHttpContextAccessor httpContextAccessor)
        : base(usuarioRepository, mapper)
    {
        _usuarioRepository = usuarioRepository;
        _validacaoService = validacaoService;
        _acessoService = acessoService;
        _httpContextAccessor = httpContextAccessor;
    }
    public async Task<ValidacaoModel> Login(UsuarioModel usuario)
    {
        var validar = await _validacaoService.ValidarLoginUsuario(usuario);
        if (!validar.Sucesso) return validar;

        var login = await _usuarioRepository.ObterPorNomeUsuarioESenha(_mapper.Map<Usuario>(usuario));
        if (login == null)
        {
            validar.Mensagem.Add("Senha ou usuário incorreto(s).");
            validar.Sucesso = false;
            return validar;
        }
        else
        {
            var now = DateTime.Now;
            await _acessoService.Atualizar(new AcessoModel
            {
                GuidUsuario = login.GuidUsuario,
                HorarioAcesso = now
            });

            login.HorarioAcesso = now;
            await _usuarioRepository.Atualizar(login);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, login.NomeUsuario),
                new Claim("GuidUsuario", login.GuidUsuario.ToString())
            };

            var claimsIdentity = new ClaimsIdentity(claims, "CookieAuthentication");
            var principal = new ClaimsPrincipal(claimsIdentity);
            var context = _httpContextAccessor.HttpContext;
            if (context == null)
            {
                throw new InvalidOperationException("HttpContext não está disponível");
            }

            await context.SignInAsync(
                "CookieAuthentication",
                principal,
                new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTime.UtcNow.AddHours(8)
                });

            return validar;
        }
    }
    public async Task<ValidacaoModel> Registrar(UsuarioModel novoUsuario)
    {
        var validar = await _validacaoService.ValidarRegistroUsuario(novoUsuario);
        if (!validar.Sucesso) return validar;

        var usuario = await _usuarioRepository.ObterPorNomeUsuario(novoUsuario.NomeUsuario);
        if (usuario != null)
        {
            validar.Sucesso = false;
            validar.Mensagem.Add("Nome de usuário já em uso.");
        }

        else
        {
            var inserido = await Inserir(novoUsuario);

            await _acessoService.Inserir(new AcessoModel
            {
                GuidUsuario = inserido.GuidUsuario,
                HorarioAcesso = DateTime.Now
            });
        }

        return validar;
    }
}