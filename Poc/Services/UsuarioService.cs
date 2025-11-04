using AutoMapper;
using Migrations.Entities;
using Poc.Models;
using Poc.Repositories.Interfaces;
using Poc.Services.Interfaces;

namespace Poc.Services;

public class UsuarioService : BaseService<Usuario, UsuarioModel>, IUsuarioService
{
    private readonly IUsuarioRepository _usuarioRepository;
    public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
        : base(usuarioRepository, mapper)
    {
        _usuarioRepository = usuarioRepository;
    }
}