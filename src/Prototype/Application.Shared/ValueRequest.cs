namespace Deiarts.Prototype.Application.Shared;

public record ValueRequest<TValue>(TValue Value)
{
    public static implicit operator TValue(ValueRequest<TValue> valueRequest) => valueRequest.Value;
    public static implicit operator ValueRequest<TValue>(TValue value) => new(value);
}