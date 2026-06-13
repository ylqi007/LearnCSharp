namespace Linq.Examples;

public static class WhereExamples
{
    public static void Run()
    {
        Console.WriteLine();
        Console.WriteLine("===== Where Examples =====");
        var users = SampleData.GetUsers();
        
        var highSalaryUsers = users.Where(user => user.Salary >= 160000);
        foreach (var user in highSalaryUsers) Console.WriteLine(user);

        var azureIdentityUsers = users.Where(user => user.Department == "Azure Identity");
        Console.WriteLine("Azure Identity users:");
        foreach (var user in azureIdentityUsers) Console.WriteLine(user.Name);
    }
}
