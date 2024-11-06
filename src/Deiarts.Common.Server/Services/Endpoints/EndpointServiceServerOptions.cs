namespace Deiarts.Common.Server.Services.Endpoints;

public static class EndpointServiceServerOptions
{
    private static readonly List<EndpointServiceResolver> Resolvers = [];
    public static void AddServiceResolver(EndpointServiceResolver resolver) => Resolvers.Add(resolver);
    public static EndpointServiceResolver? GetServiceResolver(Type type) => Resolvers.FirstOrDefault(resolver => resolver.Type == type);
}