namespace AsyncAwait.Examples;

public static class BasicTaskExamples
{
    public static async Task RunAsync()
    {
        Console.WriteLine();
        Console.WriteLine("===== Basic Task Examples =====");
        Task delayTask = Task.Delay(300);
        Console.WriteLine("Task created.");
        await delayTask;
        Console.WriteLine("Task completed.");
    }
}
