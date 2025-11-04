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
        services.AddDbContext<Context>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IClienteService, ClienteService>();
        services.AddScoped<IClienteRepository, ClienteRepository>();
        return services;
    }
}