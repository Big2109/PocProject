using Poc.Repositories;
using Poc.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Migrations.Context;
using Poc.Services.Interfaces;
using Poc.Services;

namespace Poc.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IClienteService, ClienteService>();
        services.AddScoped<IUsuarioService, UsuarioService>();
        services.AddScoped<IAcessoService, AcessoService>();
        services.AddScoped<IValidacaoService, ValidacaoService>();
        return services;
    }

    public static IServiceCollection RegisterRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IClienteRepository, ClienteRepository>();
        services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        services.AddScoped<IAcessoRepository, AcessoRepository>();
        return services;
    }
}