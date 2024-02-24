using Deiarts.Prototype.Presentation.Web.Client;
using Deiarts.Prototype.Presentation.Web.Endpoints.Materials;

namespace Deiarts.Prototype.Presentation.Web.Extensions;

public static class AppExtensions
{
    public static WebApplication UseArchitectures(this WebApplication app)
    {
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseWebAssemblyDebugging();
        }
        else
        {
            app.UseExceptionHandler("/Error", createScopeForErrors: true);
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseStaticFiles();
        app.UseAntiforgery();

        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode()
            .AddInteractiveWebAssemblyRenderMode()
            .AddAdditionalAssemblies(typeof(Client._Imports).Assembly);

        return app;
    }
    
    public static WebApplication MapDeiartsEndpoints(this WebApplication app)
    {
        var group = app.MapGroup(EndpointRoutes.Base);
        
        group.MapMaterialsEndpoints();
        
        return app;
    }
}