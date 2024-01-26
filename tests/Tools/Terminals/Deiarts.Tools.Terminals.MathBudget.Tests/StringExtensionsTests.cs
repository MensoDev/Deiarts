using FluentAssertions;

namespace Deiarts.Tools.Terminals.MathBudget.Tests;

public class StringExtensionsTests
{
    [Fact]
    public void SplitInLines_WhenTextIsSmallerThanLineLength_ShouldReturnOneLine()
    {
        // Arrange
        const string text = "This is a test";
        const int lineLength = 20;
        
        // Act
        var lines = text.SplitInLines(lineLength).ToArray();
        
        // Assert
        lines.Should().HaveCount(1);
        lines[0].Should().Be(text);
    }
    
    [Fact]
    public void SplitInLines_WhenTextIsBiggerThanLineLength_ShouldReturnMultipleLines()
    {
        // Arrange
        const string text = "This is a test";
        const int lineLength = 5;
        
        // Act
        var lines = text.SplitInLines(lineLength).ToArray();
        
        // Assert
        lines.Should().HaveCount(3);
        lines[0].Should().Be("This");
        lines[1].Should().Be("is a");
        lines[2].Should().Be("test");
    }
}