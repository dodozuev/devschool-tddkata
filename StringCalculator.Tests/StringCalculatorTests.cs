using StringCalculator;

namespace StringCalculator.Tests;

public class StringCalculatorTests
{
    [Fact]
    public void WhenEmptyString_ShouldReturnsZero()
    {
        var result = StringCalculator.Add("");
        Assert.Equal(0, result);
    }

    [Fact]
    public void WhenOnlyOneNumber_ShouldReturnTheNumber()
    {
        var result = StringCalculator.Add("1");
        Assert.Equal(1, result);
    }
}