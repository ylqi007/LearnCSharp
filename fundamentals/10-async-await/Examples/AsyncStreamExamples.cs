namespace AsyncAwait.Examples;

public static class AsyncStreamExamples
{
    public static async Task RunAsync()
    {
        Console.WriteLine();
        Console.WriteLine("===== Async Stream Examples =====");

        await foreach (var item in GenerateNumbersAsync())
        {
            Console.WriteLine($"Received {item}");
        }
    }

    private static async IAsyncEnumerable<int> GenerateNumbersAsync()
    {
        for (int i = 1; i <= 3; i++)
        {
            await Task.Delay(200);
            yield return i;
        }
    }
}
