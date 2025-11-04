using Poc.Extensions;
using Poc.AutoMapper;
var builder = WebApplication.CreateBuilder(args);

builder.ConfigureMvcPresentationServices();

builder.Services.AddMvcPresentation();
builder.Services.RegisterServices(builder.Configuration);
builder.Services.AddAutoMapper(typeof(PocProfile));

var app = builder.Build();
app.UseMvcPresentationPipeline();
app.Lifetime.ApplicationStopping.Register(() =>
{
    Console.WriteLine("Aplicação está parando… limpando recursos.");
});

app.Run();