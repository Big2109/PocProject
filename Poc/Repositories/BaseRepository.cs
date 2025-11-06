using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using Migrations.Context;
using Poc.Repositories.Interfaces;

namespace Poc.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    protected readonly Context _context;
    public BaseRepository(Context context)
    {
        _context = context;
    }

    public async Task<List<T>> Listar()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T> Inserir(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}
