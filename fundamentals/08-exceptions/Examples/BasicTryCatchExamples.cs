namespace Exceptions.Examples;

public static class BasicTryCatchExamples
{
    public static void Run()
    {
        Console.WriteLine();
        Console.WriteLine("===== Basic Try/Catch Examples =====");

        try
        {
            int result = Divide(10, 0);
            Console.WriteLine($"Result = {result}");
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine($"Caught exception: {ex.GetType().Name}");
            Console.WriteLine($"Message: {ex.Message}");
        }
    }

    private static int Divide(int left, int right)
    {
        return left / right;
    }
}
