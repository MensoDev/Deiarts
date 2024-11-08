namespace Deiarts.Common;

public record ChoiceOption<TValue>(TValue Value, string Name) where TValue : notnull
{
    public override string ToString() => Name;
}