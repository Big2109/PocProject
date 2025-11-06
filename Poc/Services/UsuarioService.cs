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

        else
        {
            await Inserir(usuario);
            return validar;
        }
    }
    public async Task<ValidacaoModel> Registrar(UsuarioModel usuario)
    {
        var validar = await _validacaoService.ValidarRegistroUsuario(usuario);
        if (!validar.Sucesso) return validar;

        else
        {
            await Inserir(usuario);
            return validar;
        }
    }
}