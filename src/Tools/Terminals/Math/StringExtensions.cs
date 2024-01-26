using System.Text;

namespace Deiarts.Tools.Terminals.MathBudget;

public static class StringExtensions
{
    public static IEnumerable<string> SplitInLines(this string text, int lineLength)
    {
        var lines = new List<string>();
        var words = text.Split(' ');

        var builder = new StringBuilder(lineLength);

        foreach (var word in words)
        {
            if (builder.Length + word.Length > lineLength)
            {
                lines.Add(builder.ToString().TrimEnd());
                builder.Clear();
            }

            builder.Append(word + " ");
        }
        
        lines.Add(builder.ToString().TrimEnd());
        return lines;
    }
}