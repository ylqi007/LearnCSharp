namespace Linq.Examples;

public static class FirstExamples
{
    public static void Run()
    {
        Console.WriteLine();
        Console.WriteLine("===== First / Single Examples =====");
        var users = SampleData.GetUsers();

        var firstHighSalaryUser = users.First(user => user.Salary >= 160000);
        Console.WriteLine($"First high salary user = {firstHighSalaryUser.Name}");

        var missingUser = users.FirstOrDefault(user => user.Id == "u999");
        Console.WriteLine(missingUser is null ? "User u999 not found" : missingUser.Name);

        var alex = users.Single(user => user.Id == "u001");
        Console.WriteLine($"Single user by id u001 = {alex.Name}");

        var maybeUser = users.SingleOrDefault(user => user.Id == "u999");
        Console.WriteLine(maybeUser is null ? "SingleOrDefault returned null" : maybeUser.Name);
    }
}
