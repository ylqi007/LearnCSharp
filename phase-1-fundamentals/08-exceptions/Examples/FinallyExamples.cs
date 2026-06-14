namespace Exceptions.Examples;

public static class FinallyExamples
{
    public static void Run()
    {
        Console.WriteLine();
        Console.WriteLine("===== Finally Examples =====");

        try
        {
            Console.WriteLine("Opening resource...");
            throw new InvalidOperationException("Something went wrong while using the resource.");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Caught: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("Cleaning up resource in finally block.");
        }
    }
}
