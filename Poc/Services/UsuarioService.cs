using AutoMapper;
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
    public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper, IValidacaoService validacaoService, IAcessoService acessoService)
        : base(usuarioRepository, mapper)
    {
        _usuarioRepository = usuarioRepository;
        _validacaoService = validacaoService;
        _acessoService = acessoService;
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

        else return validar;
    }
    public async Task<ValidacaoModel> Registrar(UsuarioModel novoUsuario)
    {
        var validar = await _validacaoService.ValidarRegistroUsuario(novoUsuario);
        if (!validar.Sucesso) return validar;

        var usuario = await _usuarioRepository.ObterPorNomeUsuario(_mapper.Map<Usuario>(novoUsuario));
        if (usuario != null)
        {
            validar.Sucesso = false;
            validar.Mensagem.Add("Nome de usuário já em uso.");
        }

        else await Inserir(novoUsuario);

        return validar;
    }
}