using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text;

namespace Deiarts.Common.Extensions;

public static class StringExtensions
{
    public static string RemoveNonSpacingMark(this string name)
    {
        var chars = name
            .Normalize(NormalizationForm.FormD)
            .Where(ch => char.GetUnicodeCategory(ch) is not UnicodeCategory.NonSpacingMark)
            .ToArray();
        return new string(chars);
    }
    
    public static bool IsNotNullOrWhiteSpace([NotNullWhen(returnValue: true)] this string? value) => !string.IsNullOrWhiteSpace(value);
}