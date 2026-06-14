using Collections.Models;

namespace Collections.Examples;

public static class DictionaryExamples
{
    public static void Run()
    {
        Console.WriteLine();
        Console.WriteLine("===== Dictionary<TKey, TValue> Examples =====");

        Dictionary<string, int> scores = new()
        {
            ["Java"] = 90,
            ["TypeScript"] = 85,
            ["C#"] = 95
        };

        Console.WriteLine($"C# score = {scores["C#"]}");

        if (scores.TryGetValue("Python", out var pythonScore))
        {
            Console.WriteLine($"Python score = {pythonScore}");
        }
        else
        {
            Console.WriteLine("Python score not found");
        }

        Dictionary<string, User> usersById = new();
        var user = new User { Id = "u001", Name = "Alex", Email = "alex@example.com" };
        usersById[user.Id] = user;
        Console.WriteLine(usersById["u001"]);

        if (usersById.TryGetValue("u999", out var missingUser))
        {
            Console.WriteLine(missingUser);
        }
        else
        {
            Console.WriteLine("User u999 not found");
        }
    }
}
