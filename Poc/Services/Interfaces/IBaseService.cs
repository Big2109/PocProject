namespace Poc.Services.Interfaces;

public interface IBaseService<TEntity, TModel>
    where TEntity : class
    where TModel : class
{
    Task<List<TModel>> Listar();
    Task<TModel> Inserir(TModel model);
    Task<TModel> Atualizar(TModel model);
}
