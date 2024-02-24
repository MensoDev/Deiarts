var app = WebApplication
    .CreateBuilder(args)
    .AddArchitectures()
    .AddInfrastructure()
    .AddEndpointsClient()
    .Build()
    .MapDeiartsEndpoints()
    .UseArchitectures();

app.Run();
