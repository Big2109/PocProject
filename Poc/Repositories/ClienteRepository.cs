using Migrations.Context;
using Migrations.Entities;
using Poc.Repositories.Interfaces;
namespace Poc.Repositories;

public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
{
    public ClienteRepository(Context context) : base(context) { }
}