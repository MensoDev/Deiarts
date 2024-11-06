using System.Text.Json.Serialization;
using Deiarts.Application;
using Deiarts.Common.Client;
using Deiarts.Common.Client.Extensions;
using Deiarts.Common.Server.Extensions;
using Deiarts.Infrastructure.Extensions;
using Deiarts.Presentation.Web.Components;
using Deiarts.Presentation.Web.Services.Endpoints;
using Menso.Tools.Exceptions;

var builder = WebApplication.CreateBuilder(args);

#region Blazor Services
// Add services to the container.
builder.Services
    .AddRazorComponents()
    .AddInteractiveServerComponents(options => options.DetailedErrors = builder.Environment.IsDevelopment())
    .AddInteractiveWebAssemblyComponents();

builder.Services.ConfigureHttpJsonOptions(options =>
{
    List<JsonSerializerContext> serializersContexts = [
        CommonClientSerializationContext.Default,
        DeiartsSerializationContext.Default
    ];
    serializersContexts.ForEach(ctx => options.SerializerOptions.TypeInfoResolverChain.Insert(0, ctx));
});

#endregion

#region Application services

ExceptionSettings.CreateDefaultExceptionHandle = ex =>  new InvalidOperationException(
    ex.CustomMessage ?? ex.DefaultMessage, 
    ex.InnerException);

builder.Services.AddCommonServerServices();
builder.Services.ConfigureLoaderOptions();
builder.Services.AddDeiartsInfrastructureServices(builder.Configuration);

#endregion

var app = builder.Build();

app.MapEndpoints(DeiartsEndpointsRegistry.Register);

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
    .AddAdditionalAssemblies(typeof(Deiarts.Presentation.Web.Client._Imports).Assembly);

await app.RunAsync();