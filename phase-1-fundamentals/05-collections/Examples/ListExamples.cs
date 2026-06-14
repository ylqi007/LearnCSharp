using Collections.Models;

namespace Collections.Examples;

public static class ListExamples
{
    public static void Run()
    {
        Console.WriteLine();
        Console.WriteLine("===== List<T> Examples =====");

        List<string> languages =
        [
            "Java",
            "TypeScript",
            "C#"
        ];

        languages.Add("Python");
        languages.Remove("Java");

        Console.WriteLine($"Count = {languages.Count}");

        foreach (var language in languages)
        {
            Console.WriteLine(language);
        }

        List<User> users =
        [
            new User { Id = "u001", Name = "Alex", Email = "alex@example.com" },
            new User { Id = "u002", Name = "Taylor" }
        ];

        users.Add(new User { Id = "u003", Name = "Jordan", Email = "jordan@example.com" });

        foreach (var user in users)
        {
            Console.WriteLine(user);
        }
    }
}
