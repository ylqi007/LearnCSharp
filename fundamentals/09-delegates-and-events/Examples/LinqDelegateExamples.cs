using DelegatesAndEvents.Models;

namespace DelegatesAndEvents.Examples;

public static class LinqDelegateExamples
{
    public static void Run()
    {
        Console.WriteLine();
        Console.WriteLine("===== LINQ Delegate Examples =====");

        List<User> users =
        [
            new User { Id = "u001", Name = "Alex", Department = "Azure Identity", IsActive = true },
            new User { Id = "u002", Name = "Taylor", Department = "Payments", IsActive = false },
            new User { Id = "u003", Name = "Morgan", Department = "Security", IsActive = true }
        ];

        Func<User, bool> isActive = user => user.IsActive;
        Func<User, string> selectName = user => user.Name;

        var activeUserNames = users
            .Where(isActive)
            .Select(selectName);

        foreach (var name in activeUserNames)
        {
            Console.WriteLine(name);
        }
    }
}
