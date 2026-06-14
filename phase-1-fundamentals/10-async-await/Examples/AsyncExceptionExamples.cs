using AsyncAwait.Services;

namespace AsyncAwait.Examples;

public static class AsyncExceptionExamples
{
    public static async Task RunAsync()
    {
        Console.WriteLine();
        Console.WriteLine("===== Async Exception Examples =====");

        var api = new ExternalApiService();

        try
        {
            string response = await api.CallFailingApiAsync();
            Console.WriteLine(response);
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Caught async exception: {ex.Message}");
        }
    }
}
