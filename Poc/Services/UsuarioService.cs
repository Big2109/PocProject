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
    public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper, IValidacaoService validacaoService)
        : base(usuarioRepository, mapper)
    {
        _usuarioRepository = usuarioRepository;
        _validacaoService = validacaoService;
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