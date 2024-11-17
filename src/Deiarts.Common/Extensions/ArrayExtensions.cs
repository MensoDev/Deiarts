namespace Deiarts.Common.Extensions;

public static class ArrayExtensions
{
    public static bool IsNotEmpty<T>(this T[] array) => array.Length > 0;
    
    public static bool IsEmpty<T>(this T[] array) => array.Length == 0;
}