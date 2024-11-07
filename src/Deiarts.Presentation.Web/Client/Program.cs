using BlazorDevKit;
using Deiarts.Common.Client.Components.Loaders;
using Deiarts.Common.Client.Extensions;
using Deiarts.Common.Client.ProblemDetails;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

#region Application services


builder.Services.AddCommonClientServices();
builder.Services.ConfigureLoaderOptions();
builder.Services.AddScoped<ProblemDetailsExceptionMessageHandler>();

builder
    .Services
    .AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("server"));

builder
    .Services
    .AddHttpClient("server", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<ProblemDetailsExceptionMessageHandler>();

#endregion

await builder.Build().RunAsync();