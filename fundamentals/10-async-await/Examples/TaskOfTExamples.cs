using AsyncAwait.Services;

namespace AsyncAwait.Examples;

public static class TaskOfTExamples
{
    public static async Task RunAsync()
    {
        Console.WriteLine();
        Console.WriteLine("===== Task<T> Examples =====");
        var userService = new UserService();
        var user = await userService.GetUserAsync("u001");
        Console.WriteLine(user);
    }
}
