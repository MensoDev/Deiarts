namespace Deiarts.Common.Application;

public record ValueRequest<TValue>(TValue Value)
{
    public static implicit operator TValue(ValueRequest<TValue> valueRequest) => valueRequest.Value;
    public static implicit operator ValueRequest<TValue>(TValue value) => new(value);
}

public record OptionalValueRequest<TValue>(TValue? Value)
{
    public static implicit operator OptionalValueRequest<TValue>(TValue? value) => new(value);
}