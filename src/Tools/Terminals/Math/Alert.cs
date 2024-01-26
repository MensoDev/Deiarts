namespace Deiarts.Tools.Terminals.MathBudget;

public static class Alert
{
    public static void WriteSuccess(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        WriteMessage("Success", message);
        Console.ResetColor();
    }
    
    public static void WriteError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        WriteMessage("Error", message);
        Console.ResetColor();
    }
    
    public static void WriteInfo(string message)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        WriteMessage("Info", message);
        Console.ResetColor();
    }

    private static void WriteMessage(string title, string message, ConsoleColor color, int padding = 20)
    {
        Console.ForegroundColor = color;
        WriteMessage(title, message, padding);
        Console.ResetColor();
    }
    
    public static void WriteMessage(string title, string message, int padding = 20)
    {
        var totalWidth = Console.WindowWidth;
        var messageWidth = message.Length + padding;
        
        var width = totalWidth < messageWidth ? totalWidth : messageWidth;
        var spaceSize = (totalWidth - width) / 2;
        
        var messages = message.SplitInLines(width - padding);
        
        
        WriteLine('=', width, spaceSize, title);
        WriteEmptyLine(width, spaceSize);
        foreach (var line in messages)
        {
            WriteMessageLine(line, width, spaceSize);
        }
        WriteEmptyLine(width, spaceSize);
        WriteLine('=', width, spaceSize);
    }

    private static void WriteLine(char token, int width, int spaceSize, string title)
    {
        var line = new string(token, width-6-title.Length);
        var spacesLine = new string(' ', spaceSize);
        Console.WriteLine($"{spacesLine}+{token}{token} {title} {line}+{spacesLine}");
    }
    
    private static void WriteLine(char token, int width, int spaceSize)
    {
        var line = new string(token, width-2);
        var spacesLine = new string(' ', spaceSize);
        Console.WriteLine($"{spacesLine}+{line}+{spacesLine}");
    }
    
    private static void WriteEmptyLine(int width, int spaceSize)
    {
        var line = new string(' ', width-2);
        var spacesLine = new string(' ', spaceSize);
        Console.WriteLine($"{spacesLine}|{line}|{spacesLine}");
    }
    
    private static void WriteMessageLine(string message, int width, int spaceSize)
    {
        var paddingsSize = width - message.Length - 2;
        var isPair = paddingsSize % 2 == 0;
        
        var paddingSizeLeft = paddingsSize / 2;
        var paddingSizeRight = isPair ? paddingSizeLeft : paddingSizeLeft + 1;
        
        var spaces = new string(' ', spaceSize);
        var paddingLeft = new string(' ', paddingSizeLeft);
        var paddingsRight =  new string(' ', paddingSizeRight);
        
        var messageLine = $"{spaces}|{paddingLeft}{message}{paddingsRight}|{spaces}";
        Console.WriteLine(messageLine);
    }
}