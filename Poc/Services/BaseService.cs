using AutoMapper;
using Poc.Repositories.Interfaces;

namespace Poc.Services;

public class BaseService<TEntity, TModel>
    where TEntity : class
    where TModel : class
{
    protected readonly IBaseRepository<TEntity> _repository;
    protected readonly IMapper _mapper;

    public BaseService(IBaseRepository<TEntity> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<List<TModel>> Listar()
    {
        var entities = await _repository.Listar();
        return _mapper.Map<List<TModel>>(entities);
    }

    public async Task<TModel> Inserir(TModel model)
    {
        var entity = _mapper.Map<TEntity>(model);
        var inserted = await _repository.Inserir(entity);
        return _mapper.Map<TModel>(inserted);
    }

    public async Task<TModel> Atualizar(TModel model)
    {
        var entity = _mapper.Map<TEntity>(model);
        var updated = await _repository.Atualizar(entity);
        return _mapper.Map<TModel>(updated);
    }

    public async Task Deletar(TModel model)
    {
        var entity = _mapper.Map<TEntity>(model);
        await _repository.Deletar(entity);
    }
}
