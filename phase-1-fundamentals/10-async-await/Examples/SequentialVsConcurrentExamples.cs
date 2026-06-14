using AsyncAwait.Services;
using System.Diagnostics;

namespace AsyncAwait.Examples;

public static class SequentialVsConcurrentExamples
{
    public static async Task RunAsync()
    {
        Console.WriteLine();
        Console.WriteLine("===== Sequential vs Concurrent Examples =====");

        var api = new ExternalApiService();

        var sequentialWatch = Stopwatch.StartNew();
        var response1 = await api.CallApiAsync("/users");
        var response2 = await api.CallApiAsync("/orders");
        sequentialWatch.Stop();

        Console.WriteLine(response1);
        Console.WriteLine(response2);
        Console.WriteLine($"Sequential elapsed = {sequentialWatch.ElapsedMilliseconds} ms");

        var concurrentWatch = Stopwatch.StartNew();
        Task<string> usersTask = api.CallApiAsync("/users");
        Task<string> ordersTask = api.CallApiAsync("/orders");

        var usersResponse = await usersTask;
        var ordersResponse = await ordersTask;
        concurrentWatch.Stop();

        Console.WriteLine(usersResponse);
        Console.WriteLine(ordersResponse);
        Console.WriteLine($"Concurrent elapsed = {concurrentWatch.ElapsedMilliseconds} ms");
    }
}
