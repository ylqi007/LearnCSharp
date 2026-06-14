using DependencyInjectionDemo.Infrastructure;
using DependencyInjectionDemo.Interfaces;
using DependencyInjectionDemo.Repositories;
using DependencyInjectionDemo.Services;

namespace DependencyInjectionDemo.Examples;

public static class Example05_MiniContainer
{
    public static void Run()
    {
        Console.WriteLine("\n--- Example 05: Mini Container ---");

        var container = new MiniContainer();

        container.Register<IUserRepository>(() => new UserRepository());
        container.Register<IAppLogger>(() => new ConsoleAppLogger());
        container.Register(() => new UserService(
            container.Resolve<IUserRepository>(),
            container.Resolve<IAppLogger>()));

        UserService service = container.Resolve<UserService>();
        Console.WriteLine(service.GetUser("u001"));
    }
}
