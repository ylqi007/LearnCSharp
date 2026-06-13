namespace Linq.Examples;

public static class AnyAllExamples
{
    public static void Run()
    {
        Console.WriteLine();
        Console.WriteLine("===== Any / All / Count Examples =====");
        var users = SampleData.GetUsers();

        bool hasHighSalaryUser = users.Any(user => user.Salary >= 200000);
        Console.WriteLine($"Has salary >= 200000: {hasHighSalaryUser}");

        bool allHaveDepartments = users.All(user => !string.IsNullOrWhiteSpace(user.Department));
        Console.WriteLine($"All users have departments: {allHaveDepartments}");

        int azureIdentityCount = users.Count(user => user.Department == "Azure Identity");
        Console.WriteLine($"Azure Identity user count = {azureIdentityCount}");
    }
}
