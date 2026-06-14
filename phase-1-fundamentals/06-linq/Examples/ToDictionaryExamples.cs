namespace Linq.Examples;

public static class ToDictionaryExamples
{
    public static void Run()
    {
        Console.WriteLine();
        Console.WriteLine("===== ToDictionary Examples =====");
        var users = SampleData.GetUsers();

        var usersById = users.ToDictionary(user => user.Id);
        Console.WriteLine(usersById["u001"]);

        if (usersById.TryGetValue("u999", out var missingUser)) Console.WriteLine(missingUser);
        else Console.WriteLine("User u999 not found");

        var usersByIdAndName = users.ToDictionary(user => user.Id, user => user.Name);
        foreach (var (id, name) in usersByIdAndName) Console.WriteLine($"{id} => {name}");
    }
}
