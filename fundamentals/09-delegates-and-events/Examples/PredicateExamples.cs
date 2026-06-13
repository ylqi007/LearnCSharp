using DelegatesAndEvents.Models;

namespace DelegatesAndEvents.Examples;

public static class PredicateExamples
{
    public static void Run()
    {
        Console.WriteLine();
        Console.WriteLine("===== Predicate Examples =====");

        Predicate<User> isActiveUser = user => user.IsActive;

        var user = new User
        {
            Id = "u001",
            Name = "Alex",
            Department = "Azure Identity",
            IsActive = true
        };

        Console.WriteLine($"Is active = {isActiveUser(user)}");
    }
}
