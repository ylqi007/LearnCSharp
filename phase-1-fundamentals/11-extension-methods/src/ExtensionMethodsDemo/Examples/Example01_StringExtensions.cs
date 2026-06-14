using ExtensionMethodsDemo.Extensions;

namespace ExtensionMethodsDemo.Examples;

public static class Example01_StringExtensions
{
    public static void Run()
    {
        Console.WriteLine("\n--- Example 01: String Extensions ---");

        string? empty = "   ";
        string email = "alex.qi@example.com";
        string name = "  aLEX     qi  ";

        Console.WriteLine(empty.IsBlank());
        Console.WriteLine(email.IsEmailLike());
        Console.WriteLine(email.MaskEmail());
        Console.WriteLine(name.ToTitleCaseSimple());
    }
}
