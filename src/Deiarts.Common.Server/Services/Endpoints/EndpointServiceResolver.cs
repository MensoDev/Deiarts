namespace Deiarts.Common.Server.Services.Endpoints;

public class EndpointServiceResolver
{
    internal Type Type { get; private init; } = default!;
    private bool RequiredDispose { get; init; }
    private Func<IServiceProvider, object?> Resolve { get; init; } = default!;
    private Action<object?> Dispose { get;  init; } = default!;
    
    public static EndpointServiceResolver Create<TService>(Func<IServiceProvider, object?> resolver)
    {
        return new EndpointServiceResolver
        {
            Type = typeof(TService),
            Resolve = resolver,
            RequiredDispose = typeof(IDisposable).IsAssignableFrom(typeof(TService)),
            Dispose = service =>
            {
                if (service is not IDisposable disposable) return;
                
                Console.WriteLine($"Disposing {service.GetType().Name}");
                disposable.Dispose();
                Console.WriteLine($"Disposed {service.GetType().Name}");
            }
        };
    }
    
    internal EndpointServiceOrRequestResult ResolveService(IServiceProvider serviceProvider)
    {
        return new EndpointServiceOrRequestResult
        {
            Value = Resolve(serviceProvider),
            RequiredDispose = RequiredDispose,
            Dispose = Dispose
        };
    }
}