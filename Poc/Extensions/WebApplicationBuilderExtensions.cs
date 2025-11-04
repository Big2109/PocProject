using AutoMapper;
using Poc.AutoMapper;
using Serilog;

namespace Poc.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static WebApplicationBuilder ConfigureMvcPresentationServices(this WebApplicationBuilder builder)
    {
        builder.Host.UseSerilog((context, configuration) =>
        {
            configuration
                .ReadFrom.Configuration(context.Configuration)
                .Enrich.FromLogContext();
        });

        return builder;
    }

    public static void ConfigureAutomapper(WebApplicationBuilder builder)
    {
        var mapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<PocProfile>();
        });

        IMapper mapper = mapperConfig.CreateMapper();
        builder.Services.AddSingleton(mapper);
    }
}