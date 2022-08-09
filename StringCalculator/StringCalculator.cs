namespace StringCalculator;

public static class StringCalculator
{
    public static int Add(string numbers)
    {
        return string.IsNullOrEmpty(numbers) ? 0 : int.Parse(numbers);
    }
}