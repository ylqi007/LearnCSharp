using DelegatesAndEvents.Models;

namespace DelegatesAndEvents.Examples;

public static class LambdaExamples
{
    public static void Run()
    {
        Console.WriteLine();
        Console.WriteLine("===== Lambda Examples =====");

        List<User> users =
        [
            new User { Id = "u001", Name = "Alex", Department = "Azure Identity", IsActive = true },
            new User { Id = "u002", Name = "Taylor", Department = "Payments", IsActive = false }
        ];

        var activeUsers = users
            .Where(user => user.IsActive)
            .Select(user => user.Name);

        foreach (var name in activeUsers)
        {
            Console.WriteLine(name);
        }
    }
}
