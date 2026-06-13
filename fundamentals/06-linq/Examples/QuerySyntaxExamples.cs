namespace Linq.Examples;

public static class QuerySyntaxExamples
{
    public static void Run()
    {
        Console.WriteLine();
        Console.WriteLine("===== Query Syntax Examples =====");
        var users = SampleData.GetUsers();

        var query =
            from user in users
            where user.Salary >= 160000
            orderby user.Name
            select user;

        foreach (var user in query) Console.WriteLine(user);

        var methodSyntax = users
            .Where(user => user.Salary >= 160000)
            .OrderBy(user => user.Name)
            .Select(user => user);

        Console.WriteLine("Equivalent method syntax:");
        foreach (var user in methodSyntax) Console.WriteLine(user.Name);
    }
}
