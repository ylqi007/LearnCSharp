using TypesAndNullability.Models;

namespace TypesAndNullability.Examples;

public static class RequiredExamples
{
    public static void Run()
    {
        Console.WriteLine();
        Console.WriteLine("===== Required Examples =====");

        var user = new User
        {
            UserId = "alex"
        };

        Console.WriteLine(
            $"UserId = {user.UserId}");

        //
        // 取消注释观察编译错误
        //
        // var invalidUser = new User();
        //
    }
}