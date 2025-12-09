using Poc.Extensions;
using Poc.AutoMapper;
using Migrations.Context;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

WebApplicationBuilderExtensions.ConfigureVue(builder);
WebApplicationBuilderExtensions.ConfigureAuthentication(builder);
builder.ConfigureMvcPresentationServices();

builder.Services.AddMvcPresentation();
builder.Services.AddDbContextFactory<Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.RegisterServices();
builder.Services.RegisterRepositories();
builder.Services.AddAutoMapper(typeof(PocProfile));
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession();

var app = builder.Build();
UserSessionHelper.Configure(app.Services.GetRequiredService<IHttpContextAccessor>());
app.UseMvcPresentationPipeline();
app.UseCors("AllowVueApp");
app.UseSession();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseRequestLocalization();
app.UseStaticFiles();

app.Lifetime.ApplicationStopping.Register(() =>
{
    Console.WriteLine("Aplicação está parando… limpando recursos.");
});

app.Run();