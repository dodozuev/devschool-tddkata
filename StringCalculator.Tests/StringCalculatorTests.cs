using StringCalculator;

namespace StringCalculator.Tests;

public class StringCalculatorTests
{
    [Fact]
    public void WhenEmptyString_ShouldReturnZero()
    {
        var result = StringCalculator.Add(" ");
        Assert.Equal(0, result);
    }

    [Fact]
    public void WhenOnlyOneNumber_ShouldReturnTheNumber()
    {
        var result = StringCalculator.Add("1");
        Assert.Equal(1, result);
    }

    [Fact]
    public void WhenSeveralNumbers_ShouldAddTheNumbers()
    {
        var result = StringCalculator.Add("1, 2");
        Assert.Equal(3, result);
    }

    [Fact]
    public void WhenComma_ShouldReturnZero()
    {
        var result = StringCalculator.Add(",");
        Assert.Equal(0, result);
    }

    [Fact]
    public void WhenMoreThanTwoNumbers_ShouldAddTheNumbers()
    {
        var result = StringCalculator.Add("1, 2, 1, 2, 4");
        Assert.Equal(10, result);
    }
}