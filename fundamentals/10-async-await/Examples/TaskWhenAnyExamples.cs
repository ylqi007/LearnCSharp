using AsyncAwait.Services;

namespace AsyncAwait.Examples;

public static class TaskWhenAnyExamples
{
    public static async Task RunAsync()
    {
        Console.WriteLine();
        Console.WriteLine("===== Task.WhenAny Examples =====");

        var api = new ExternalApiService();

        Task<string> fastTask = api.CallApiAsync("/fast");
        Task<string> slowTask = api.CallSlowApiAsync("/slow");

        Task<string> completedTask = await Task.WhenAny(fastTask, slowTask);
        string result = await completedTask;

        Console.WriteLine($"First completed result = {result}");
    }
}
