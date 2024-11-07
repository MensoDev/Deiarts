using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Deiarts.Common.Extensions;

public static class EnumExtensions
{
    public static EnumOption<TEnum>[] ToEnumOptions<TEnum>() where TEnum : struct, Enum
    {
        var enumValues = Enum.GetValues(typeof(TEnum)).Cast<TEnum>().ToList();
        var options = new List<EnumOption<TEnum>>(enumValues.Count);
        options.AddRange(enumValues.Select(enumValue => enumValue.ToEnumOption()));
        return options.ToArray();
    }
    
    public static EnumOption<TEnum> ToEnumOption<TEnum>(this TEnum value) where TEnum : struct, Enum
    {
        if (value.Equals(default(TEnum)))
        {
            return new EnumOption<TEnum>(value, string.Empty, string.Empty);
        }
        
        var enumType = typeof(TEnum);
        var name = value.ToString();
        var field = enumType.GetField(name);

        if (field is null)
        {
            return new EnumOption<TEnum>(value, "Unknown", string.Empty);
        }
        
        var displayAttribute = field?.GetCustomAttribute<DisplayAttribute>();
        var displayName = displayAttribute?.Name ?? name;
        var shortName = displayAttribute?.ShortName ?? string.Empty;

        return new EnumOption<TEnum>(value, displayName, shortName);
    }
}