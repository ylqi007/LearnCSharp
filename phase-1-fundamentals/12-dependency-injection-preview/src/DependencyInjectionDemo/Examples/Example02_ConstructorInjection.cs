using DependencyInjectionDemo.Infrastructure;
using DependencyInjectionDemo.Repositories;
using DependencyInjectionDemo.Services;

namespace DependencyInjectionDemo.Examples;

public static class Example02_ConstructorInjection
{
    public static void Run()
    {
        Console.WriteLine("\n--- Example 02: Constructor Injection ---");

        var repository = new UserRepository();
        var logger = new ConsoleAppLogger();
        var service = new UserService(repository, logger);  // Dependency Injection，把依赖从类里面拿出去

        var user = service.GetUser("u001");
        Console.WriteLine(user);
    }
}
