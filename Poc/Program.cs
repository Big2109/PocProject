using Poc.Extensions;
using Poc.AutoMapper;
using Migrations.Context;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

WebApplicationBuilderExtensions.ConfigureVue(builder);
builder.ConfigureMvcPresentationServices();

builder.Services.AddMvcPresentation();
builder.Services.AddDbContextFactory<Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.RegisterServices(builder.Configuration);
builder.Services.RegisterRepositories(builder.Configuration);
builder.Services.AddAutoMapper(typeof(PocProfile));

var app = builder.Build();
app.UseMvcPresentationPipeline();
app.Lifetime.ApplicationStopping.Register(() =>
{
    Console.WriteLine("Aplicação está parando… limpando recursos.");
});
app.UseCors("AllowVueApp");

app.Run();