namespace Deiarts.Common.Application;

public record ValueResponse<TValue>(TValue Value)
{
    public static implicit operator TValue(ValueResponse<TValue> valueResponse) => valueResponse.Value;
    public static implicit operator ValueResponse<TValue>(TValue value) => new(value);
}