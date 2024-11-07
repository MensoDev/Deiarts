using Deiarts.Common.Extensions;

namespace Deiarts.Common;

public record EnumOption<TEnum>(TEnum Value, string Name, string ShortName) where TEnum : struct, Enum
{
    public string CombinedName => ShortName.IsNotNullOrWhiteSpace() ? $"{Name} ({ShortName})" : Name;
}