namespace Deiarts.Common.Server.Services.Endpoints;

internal class EndpointServiceOrRequestResult
{
    public required object? Value { get; init; }
    public required bool RequiredDispose { get; init; }
    public Action<object?>? Dispose { get;  init; }
    
    public void TryDisposeValue()
    {
        if (RequiredDispose && Dispose is not null)
        {
            Dispose(Value);
        }
    }
}