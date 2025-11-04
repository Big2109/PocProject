using AutoMapper;
using Migrations.Entities;
using Poc.Models;
namespace Poc.AutoMapper;

public class PocProfile : Profile
{
    private void ClienteMap()
    {
        CreateMap<Cliente, ClienteModel>()
        .ForMember(c => c.Nome, opt => opt.MapFrom(cm => cm.Nome))
        .ForMember(c => c.Email, opt => opt.MapFrom(cm => cm.Email))
        .ForMember(c => c.GuidCliente, opt => opt.MapFrom(cm => cm.GuidCliente))
        .ReverseMap();
    }

    public PocProfile()
    {
        AllowNullCollections = true;
        ClienteMap();
    }
}
