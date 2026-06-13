namespace Exceptions.Examples;

public static class ThrowExamples
{
    public static void Run()
    {
        Console.WriteLine();
        Console.WriteLine("===== Throw Examples =====");

        try
        {
            ValidateName("");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Validation failed: {ex.Message}");
        }

        try
        {
            ValidateName(null);
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine($"Null argument: {ex.ParamName}");
        }
    }

    private static void ValidateName(string? name)
    {
        if (name is null)
        {
            throw new ArgumentNullException(nameof(name));
        }

        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name cannot be empty.", nameof(name));
        }
    }
}
