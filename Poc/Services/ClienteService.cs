using AutoMapper;
using Migrations.Entities;
using Poc.Models;
using Poc.Repositories.Interfaces;
using Poc.Services.Interfaces;

namespace Poc.Services;

public class ClienteService : BaseService<Cliente, ClienteModel>, IClienteService
{
    private readonly IClienteRepository _clienteRepository;
    public ClienteService(IClienteRepository clienteRepository, IMapper mapper)
        : base(clienteRepository, mapper)
    {
        _clienteRepository = clienteRepository;
    }
}