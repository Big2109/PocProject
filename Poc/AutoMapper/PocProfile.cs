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
        .ForMember(u => u.GuidUsuario, opt => opt.MapFrom(um => um.GuidUsuario))
        .ForMember(u => u.Nome, opt => opt.MapFrom(um => um.Nome))
        .ForMember(u => u.NomeUsuario, opt => opt.MapFrom(um => um.NomeUsuario))
        .ForMember(u => u.Email, opt => opt.MapFrom(um => um.Email))
        .ForMember(u => u.Senha, opt => opt.MapFrom(um => um.Senha))
        .ForMember(u => u.CriadoEm, opt => opt.MapFrom(um => um.CriadoEm))
        .ForMember(u => u.HorarioAcesso, opt => opt.MapFrom(um => um.HorarioAcesso))
        .ReverseMap();
    }

    private void AcessoMap()
    {
        CreateMap<Acesso, AcessoModel>()
        .ForMember(a => a.GuidUsuario, opt => opt.MapFrom(am => am.GuidUsuario))
        .ForMember(a => a.HorarioAcesso, opt => opt.MapFrom(am => am.HorarioAcesso))
        .ForMember(a => a.Ativo, opt => opt.MapFrom(am => am.Ativo))
        .ReverseMap();
    }
    private void ProdutoMap()
    {
        CreateMap<Produto, ProdutoModel>()
        .ForMember(p => p.GuidUsuario, opt => opt.MapFrom(pm => pm.GuidUsuario))
        .ForMember(p => p.GuidProduto, opt => opt.MapFrom(pm => pm.GuidProduto))
        .ForMember(p => p.Nome, opt => opt.MapFrom(pm => pm.Nome))
        .ForMember(p => p.Descricao, opt => opt.MapFrom(pm => pm.Descricao))
        .ForMember(p => p.Icone, opt => opt.MapFrom(pm => pm.Icone))
        .ForMember(p => p.CorHex, opt => opt.MapFrom(pm => pm.CorHex))
        .ForMember(p => p.CriadoEm, opt => opt.MapFrom(pm => pm.CriadoEm))
        .ForMember(p => p.AtualizadoEm, opt => opt.MapFrom(pm => pm.AtualizadoEm))
        .ReverseMap();
    }

    public PocProfile()
    {
        AllowNullCollections = true;
        ClienteMap();
        UsuarioMap();
        AcessoMap();
        ProdutoMap();
    }
}
