using Deiarts.Prototype.Presentation.Web.Client.Extensions;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

await WebAssemblyHostBuilder
    .CreateDefault(args)
    .AddArchitecture()
    .AddEndpointsClient()
    .Build()
    .RunAsync();
