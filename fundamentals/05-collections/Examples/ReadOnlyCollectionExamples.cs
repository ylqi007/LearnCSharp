using Collections.Models;

namespace Collections.Examples;

public static class ReadOnlyCollectionExamples
{
    public static void Run()
    {
        Console.WriteLine();
        Console.WriteLine("===== Read-only Collection Examples =====");

        List<User> internalUsers =
        [
            new User { Id = "u001", Name = "Alex", Email = "alex@example.com" },
            new User { Id = "u002", Name = "Taylor" }
        ];

        IReadOnlyList<User> readOnlyUsers = internalUsers;

        Console.WriteLine($"Read-only count = {readOnlyUsers.Count}");
        foreach (var user in readOnlyUsers) Console.WriteLine(user);

        // readOnlyUsers.Add(...) does not compile.
        // However, the original List<T> can still be modified internally.
        internalUsers.Add(new User { Id = "u003", Name = "Jordan" });

        Console.WriteLine($"Read-only count after internal update = {readOnlyUsers.Count}");
    }
}
