using Collections.Models;

namespace Collections.Examples;

public static class IterationExamples
{
    public static void Run()
    {
        Console.WriteLine();
        Console.WriteLine("===== Iteration Examples =====");

        List<User> users =
        [
            new User { Id = "u001", Name = "Alex", Email = "alex@example.com" },
            new User { Id = "u002", Name = "Taylor" }
        ];

        Console.WriteLine("foreach:");
        foreach (var user in users)
        {
            Console.WriteLine(user.Name);
        }

        Console.WriteLine("for:");
        for (int i = 0; i < users.Count; i++)
        {
            Console.WriteLine($"{i}: {users[i].Name}");
        }

        Console.WriteLine("Dictionary iteration:");
        Dictionary<string, User> usersById = users.ToDictionary(user => user.Id, user => user);

        foreach (KeyValuePair<string, User> entry in usersById)
        {
            Console.WriteLine($"{entry.Key} => {entry.Value.Name}");
        }

        Console.WriteLine("Dictionary deconstruction:");
        foreach (var (id, user) in usersById)
        {
            Console.WriteLine($"{id} => {user.Email ?? "N/A"}");
        }
    }
}
