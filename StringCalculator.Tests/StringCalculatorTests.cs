using StringCalculator;

namespace StringCalculator.Tests;

public class StringCalculatorTests
{
    [Fact]
    public void ShouldAdd_TwoNumbers()
    {
        var result = StringCalculator.Add("");
        Assert.Equal(0, result);
    }
}