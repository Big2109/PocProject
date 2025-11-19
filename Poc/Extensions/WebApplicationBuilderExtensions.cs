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

    public static void ConfigureVue(WebApplicationBuilder builder)
    {
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowVueApp",
                policy => policy
                    .WithOrigins("http://localhost:5173")
                    .AllowAnyHeader()
                    .AllowAnyMethod());
        });
    }

    public static void ConfigureAuthentication(WebApplicationBuilder builder)
    {
        builder.Services.AddAuthentication("CookieAuthentication")
            .AddCookie("CookieAuthentication", config =>
            {
                config.Cookie.Name = "PocCookie";
                config.LoginPath = new PathString("/Login");
                config.ExpireTimeSpan = TimeSpan.FromHours(8);
            });
    }
}