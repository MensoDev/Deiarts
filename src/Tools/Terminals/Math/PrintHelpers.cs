namespace Deiarts.Tools.Terminals.MathBudget;

public static class PrintHelpers
{
    private const char BorderToken = '*';
    
    public static void PrintHeader(string title)
    {
        Console.WriteLine(Environment.NewLine);
        var width = Console.WindowWidth;
        var header = new string(BorderToken, width);
        var headerTitle = new string(' ', (width - title.Length) / 2) + title;
        Console.WriteLine(header);
        Console.WriteLine(headerTitle);
        Console.WriteLine(header);
        Console.WriteLine(Environment.NewLine);
    }
    
    public static void PrintFooter()
    {
        var width = Console.WindowWidth;
        var footer = new string(BorderToken, width);
        Console.WriteLine(footer);
        Console.WriteLine(Environment.NewLine);
    }
}