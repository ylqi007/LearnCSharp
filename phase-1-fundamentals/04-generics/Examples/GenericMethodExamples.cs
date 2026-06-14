namespace Generics.Examples;

public static class GenericMethodExamples
{
    public static void Run()
    {
        Console.WriteLine();
        Console.WriteLine("===== Generic Method Examples =====");

        PrintValue("Hello C#");
        PrintValue(42);
        PrintValue(DateTime.UtcNow);

        var first = GetFirstOrDefault(new List<string> { "Alex", "Taylor" });
        Console.WriteLine($"First name = {first}");
    }

    private static void PrintValue<T>(T value)
    {
        Console.WriteLine($"Input Type = {typeof(T).Name}, \t Value = {value}");
    }

    private static T? GetFirstOrDefault<T>(IEnumerable<T> values)
    {
        foreach (var value in values)
        {
            return value;
        }

        return default;
    }
}
