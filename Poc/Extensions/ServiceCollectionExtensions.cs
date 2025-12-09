using Poc.Repositories;
using Poc.Repositories.Interfaces;
using Poc.Services.Interfaces;
using Poc.Services;
using System.Globalization;
using Microsoft.AspNetCore.Localization;

namespace Poc.Extensions;

public static class ServiceCollectionExtensions
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddControllersWithViews();

        var cultureInfo = new CultureInfo("pt-BR");

        services.Configure<RequestLocalizationOptions>(options =>
        {
            options.DefaultRequestCulture = new RequestCulture(cultureInfo);
            options.SupportedCultures = new List<CultureInfo> { cultureInfo };
            options.SupportedUICultures = new List<CultureInfo> { cultureInfo };
        });
    }
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IClienteService, ClienteService>();
        services.AddScoped<IUsuarioService, UsuarioService>();
        services.AddScoped<IAcessoService, AcessoService>();
        services.AddScoped<IValidacaoService, ValidacaoService>();
        services.AddScoped<IProdutoService, ProdutoService>();
        return services;
    }

    public static IServiceCollection RegisterRepositories(this IServiceCollection services)
    {
        services.AddScoped<IClienteRepository, ClienteRepository>();
        services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        services.AddScoped<IAcessoRepository, AcessoRepository>();
        services.AddScoped<IProdutoRepository, ProdutoRepository>();
        return services;
    }
}