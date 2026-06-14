namespace Exceptions.Examples;

public static class MultipleCatchExamples
{
    public static void Run()
    {
        Console.WriteLine();
        Console.WriteLine("===== Multiple Catch Examples =====");

        try
        {
            string? value = null;
            Console.WriteLine(value!.Length);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Argument exception: {ex.Message}");
        }
        catch (NullReferenceException ex)
        {
            Console.WriteLine($"Null reference exception: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"General exception: {ex.Message}");
        }
    }
}
