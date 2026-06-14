namespace Exceptions.Examples;

public static class TryParseExamples
{
    public static void Run()
    {
        Console.WriteLine();
        Console.WriteLine("===== TryParse Examples =====");

        string validNumber = "123";
        string invalidNumber = "abc";

        if (int.TryParse(validNumber, out var parsedNumber))
        {
            Console.WriteLine($"Parsed valid number = {parsedNumber}");
        }

        if (int.TryParse(invalidNumber, out var invalidParsedNumber))
        {
            Console.WriteLine($"Parsed invalid number = {invalidParsedNumber}");
        }
        else
        {
            Console.WriteLine($"Could not parse '{invalidNumber}'");
        }
    }
}
