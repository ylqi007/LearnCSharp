namespace Exceptions.Examples;

public static class RethrowExamples
{
    public static void Run()
    {
        Console.WriteLine();
        Console.WriteLine("===== Rethrow Examples =====");

        try
        {
            OuterMethod();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Caught in Run: {ex.GetType().Name}");
            Console.WriteLine("Use 'throw;' instead of 'throw ex;' to preserve stack trace.");
        }
    }

    private static void OuterMethod()
    {
        try
        {
            InnerMethod();
        }
        catch
        {
            Console.WriteLine("Logging exception in OuterMethod, then rethrowing...");
            throw;
        }
    }

    private static void InnerMethod()
    {
        throw new InvalidOperationException("Failure from InnerMethod.");
    }
}
