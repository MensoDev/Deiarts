namespace Deiarts.Common.Extensions;

public static class ObjectExtensions
{
    public static bool IsNotNull<T>(this T? value) where T : class => value is not null; 
}