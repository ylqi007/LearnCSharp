using AsyncAwait.Services;

namespace AsyncAwait.Examples;

public static class TaskWhenAllExamples
{
    public static async Task RunAsync()
    {
        Console.WriteLine();
        Console.WriteLine("===== Task.WhenAll Examples =====");

        var api = new ExternalApiService();

        Task<string> usersTask = api.CallApiAsync("/users");
        Task<string> ordersTask = api.CallApiAsync("/orders");
        Task<string> tokensTask = api.CallApiAsync("/tokens");

        string[] responses = await Task.WhenAll(usersTask, ordersTask, tokensTask);

        foreach (var response in responses)
        {
            Console.WriteLine(response);
        }
    }
}
