namespace TypesAndNullability.Examples;

public static class NullCoalescingExamples
{
    public static void Run()
    {
        Console.WriteLine();
        Console.WriteLine("===== Null Coalescing Examples =====");

        string? email = null;

        string displayName =
            email ?? "Unknown User";

        Console.WriteLine(displayName);

        email = "alex@example.com";

        displayName =
            email ?? "Unknown User";

        Console.WriteLine(displayName);
    }
}