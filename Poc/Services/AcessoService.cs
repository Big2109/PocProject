using AutoMapper;
using Migrations.Entities;
using Poc.Models;
using Poc.Repositories.Interfaces;
using Poc.Services.Interfaces;

namespace Poc.Services;

public class AcessoService : BaseService<Acesso, AcessoModel>, IAcessoService
{
    private readonly IAcessoRepository _acessoRepository;
    public AcessoService(IAcessoRepository acessoRepository, IMapper mapper)
        : base(acessoRepository, mapper)
    {
        _acessoRepository = acessoRepository;
    }

    public async Task<AcessoModel> ObterPorGuidUsuario(Guid guidUsuario)
    {
        return _mapper.Map<AcessoModel>(await _acessoRepository.ObterPorGuidUsuario(guidUsuario));
    }
}