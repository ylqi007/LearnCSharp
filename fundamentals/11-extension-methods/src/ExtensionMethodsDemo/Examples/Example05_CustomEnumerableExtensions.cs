using ExtensionMethodsDemo.Extensions;

namespace ExtensionMethodsDemo.Examples;

public static class Example05_CustomEnumerableExtensions
{
    public static void Run()
    {
        Console.WriteLine("\n--- Example 05: Custom Enumerable Extensions ---");

        List<string?> names = ["Alex", null, "Cathy", null, "David"];

        string result = names
            .WhereNotNull()
            .TakeUntil(name => name == "David")
            .JoinAsText(" | ");

        Console.WriteLine(result);
    }
}
