namespace TypesAndNullability.Examples;

public static class NullForgivingExamples
{
    public static void Run()
    {
        Console.WriteLine();
        Console.WriteLine("===== Null Forgiving Examples =====");

        string? value = null;

        try
        {
            Console.WriteLine(
                value!.Length);
        }
        catch (NullReferenceException)
        {
            Console.WriteLine(
                "NullReferenceException thrown");
        }

        value = "Hello";

        Console.WriteLine(
            value!.Length);
    }
}