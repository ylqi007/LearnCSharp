using ExtensionMethodsDemo.Extensions;

namespace ExtensionMethodsDemo.Examples;

public static class Example03_Chaining
{
    public static void Run()
    {
        Console.WriteLine("\n--- Example 03: Chaining ---");

        string raw = "  aLEX     qi  ";

        string normalized = raw
            .ToTitleCaseSimple()
            .Replace(" ", ".")
            .ToLowerInvariant();

        Console.WriteLine(normalized);
    }
}
