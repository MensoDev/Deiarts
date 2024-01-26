using System.Globalization;
using Sharprompt;

namespace Deiarts.Tools.Terminals.MathBudget;

public static class PrintHelpers
{
    private const char BorderToken = '*';
    public static readonly CultureInfo Culture = CultureInfo.GetCultureInfo("pt-BR");
    
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
    
    public static void PrintError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();
    }
    
    public static void PrintSuccess(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        
        var width = Console.WindowWidth;
        var alert = new string(BorderToken, width);
        var alertMessage = new string(' ', (width - message.Length) / 2) + message;
        NewLine();
        Console.WriteLine(alert);
        Console.WriteLine(alertMessage);
        Console.WriteLine(alert);
        NewLine();
        
        Console.ResetColor();
    }
    
    public static void PrintInfo(string message)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        
        var width = Console.WindowWidth;
        var alert = new string(BorderToken, width);
        var alertMessage = new string(' ', (width - message.Length) / 2) + message;
        NewLine();
        Console.WriteLine(alert);
        Console.WriteLine(alertMessage);
        Console.WriteLine(alert);
        NewLine();
        
        Console.ResetColor();
    }

    public static void WriteCurrency(decimal money, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        WriteCurrency(money);
        Console.ResetColor();
    }
    
    public static void WriteCurrency(decimal money)
    {
        Write(money.ToString("C", Culture));
    }
    
    public static void Write(string text, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Write(text);
        Console.ResetColor();
    }
    
    public static void Write(string text)
    {
        Console.Write(text);
    }
    
    public static void WriteLine(string text, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        WriteLine(text);
        Console.ResetColor();
    }
    
    public static void WriteLine(string text) => Console.WriteLine(text);

    public static void WriteDashedLine() => Console.WriteLine(new string('-', Console.WindowWidth));
    
    public static void WriteDashedLine(ConsoleColor color)
    {
        Console.ForegroundColor = color;
        WriteDashedLine();
        Console.ResetColor();
    }
    
    public static void WriteDashedLine(string text)
    {
        var width = Console.WindowWidth;
        var textWidth = text.Length;
        var left = (width - textWidth) / 2;
        var right = width - left - textWidth;
        Console.WriteLine($"{new string('-', left)}{text}{new string('-', right)}");
    }
    
    public static void WriteDashedLine(string text, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        WriteDashedLine(text);
        Console.ResetColor();
    }
    
    public static void NewLine() => Console.WriteLine(Environment.NewLine);
    public static void SkipLine() => Console.WriteLine();
    
    public static void Clear() => Console.Clear();

    #region Print Info

    public static void PrintInfo(string label, string message, ConsoleColor color = ConsoleColor.DarkGray)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write($"{label}: ");
        Console.ForegroundColor = color;
        Console.WriteLine(message);
        Console.ResetColor();
    }
    
    public static void PrintCurrencyInfo(string label, decimal value, ConsoleColor color = ConsoleColor.DarkGray)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write($"{label}: ");
        Console.ForegroundColor = color;
        WriteCurrency(value);
        SkipLine();
        Console.ResetColor();
    }

    #endregion

    #region Questions

    public static bool Confirm(string question)
    {
        var confirm = Prompt.Confirm(question);
        return confirm;
    }

    #endregion
}