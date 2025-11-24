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
    private void UsuarioMap()
    {
        CreateMap<Usuario, UsuarioModel>()
        .ForMember(c => c.GuidUsuario, opt => opt.MapFrom(cm => cm.GuidUsuario))
        .ForMember(c => c.Nome, opt => opt.MapFrom(cm => cm.Nome))
        .ForMember(c => c.NomeUsuario, opt => opt.MapFrom(cm => cm.NomeUsuario))
        .ForMember(c => c.Email, opt => opt.MapFrom(cm => cm.Email))
        .ForMember(c => c.Senha, opt => opt.MapFrom(cm => cm.Senha))
        .ForMember(c => c.CriadoEm, opt => opt.MapFrom(cm => cm.CriadoEm))
        .ForMember(c => c.HorarioAcesso, opt => opt.MapFrom(cm => cm.HorarioAcesso))
        .ReverseMap();
    }

    private void AcessoMap()
    {
        CreateMap<Acesso, AcessoModel>()
        .ForMember(c => c.GuidUsuario, opt => opt.MapFrom(cm => cm.GuidUsuario))
        .ForMember(c => c.HorarioAcesso, opt => opt.MapFrom(cm => cm.HorarioAcesso))
        .ReverseMap();
    }

    public PocProfile()
    {
        AllowNullCollections = true;
        ClienteMap();
        UsuarioMap();
        AcessoMap();
    }
}
