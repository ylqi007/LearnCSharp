namespace AsyncAwait.Examples;

public static class AsyncAwaitExamples
{
    public static async Task RunAsync()
    {
        Console.WriteLine();
        Console.WriteLine("===== Async / Await Examples =====");
        Console.WriteLine("Before await");
        await SimulateIoAsync();
        Console.WriteLine("After await");
    }

    private static async Task SimulateIoAsync()
    {
        await Task.Delay(300);
        Console.WriteLine("Simulated I/O completed.");
    }
}
