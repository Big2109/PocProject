namespace Poc.Extensions;

public static class WebApplicationExtensions
{
    public static void AddMvcPresentation(this IServiceCollection services)
    {
        services.AddControllersWithViews();
    }
    public static WebApplication UseMvcPresentationPipeline(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
            app.UseDeveloperExceptionPage();
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.MapDefaultControllerRoute();

        return app;
    }
}