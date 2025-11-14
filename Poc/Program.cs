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
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession();

var app = builder.Build();
UserSessionHelper.Configure(app.Services.GetRequiredService<IHttpContextAccessor>());
app.UseMvcPresentationPipeline();
app.Lifetime.ApplicationStopping.Register(() =>
{
    Console.WriteLine("Aplicação está parando… limpando recursos.");
});
app.UseCors("AllowVueApp");
app.UseSession();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();