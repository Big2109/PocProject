namespace Poc.Repositories.Interfaces;

public interface IBaseRepository<T> where T : class
{
    Task<List<T>> Listar();
    Task<T> Inserir(T entity);
    Task<T> Atualizar(T entity);
    Task Deletar(T entity);
}