namespace StringCalculator;

public static class StringCalculator
{
    public static int Add(string numbers)
    {
        if (string.IsNullOrWhiteSpace(numbers))
        {
            return 0;
        }

        return numbers.Split(",")
            .Select(x => x.Trim())
            .Where(x => !string.IsNullOrEmpty(x))
            .Select(int.Parse)
            .Sum();
    }
}