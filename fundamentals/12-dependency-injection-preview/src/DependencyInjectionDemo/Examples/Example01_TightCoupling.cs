using DependencyInjectionDemo.Services;

namespace DependencyInjectionDemo.Examples;

public static class Example01_TightCoupling
{
    public static void Run()
    {
        Console.WriteLine("\n--- Example 01: Tight Coupling ---");

        var service = new TightlyCoupledUserService();
        var user = service.GetUser("u001");

        Console.WriteLine(user);
        Console.WriteLine("Problem: UserService directly creates UserRepository, so it is hard to replace or test.");
    }
}
