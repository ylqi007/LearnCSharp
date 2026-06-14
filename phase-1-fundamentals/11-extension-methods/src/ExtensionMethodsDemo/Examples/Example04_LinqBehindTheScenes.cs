using ExtensionMethodsDemo.Models;

namespace ExtensionMethodsDemo.Examples;

public static class Example04_LinqBehindTheScenes
{
    public static void Run()
    {
        Console.WriteLine("\n--- Example 04: LINQ Behind The Scenes ---");

        List<User> users = SampleUsers();

        IEnumerable<string> activeNames = users
            .Where(user => user.IsActive)
            .OrderBy(user => user.Name)
            .Select(user => user.Name);

        foreach (string name in activeNames)
        {
            Console.WriteLine(name);
        }

        // The syntax above is extension-method syntax.
        // Conceptually similar to:
        // Enumerable.Select(Enumerable.OrderBy(Enumerable.Where(users, user => user.IsActive), user => user.Name), user => user.Name)
    }

    private static List<User> SampleUsers()
    {
        return
        [
            new("u001", "Alex", "alex@example.com", true, DateTime.UtcNow.AddDays(-3)),
            new("u002", "Bob", "bob@example.com", false, DateTime.UtcNow.AddDays(-30)),
            new("u003", "Cathy", "cathy@example.com", true, DateTime.UtcNow.AddDays(-7))
        ];
    }
}
