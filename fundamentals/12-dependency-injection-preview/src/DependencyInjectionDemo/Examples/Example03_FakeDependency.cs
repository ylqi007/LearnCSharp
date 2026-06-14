using DependencyInjectionDemo.Infrastructure;
using DependencyInjectionDemo.Repositories;
using DependencyInjectionDemo.Services;

namespace DependencyInjectionDemo.Examples;

public static class Example03_FakeDependency
{
    public static void Run()
    {
        Console.WriteLine("\n--- Example 03: Fake Dependency ---");

        var fakeRepository = new FakeUserRepository();
        var logger = new ConsoleAppLogger();
        var service = new UserService(fakeRepository, logger);  // 简单替换，完全不访问数据库，方便测试

        var user = service.GetUser("any-id");
        Console.WriteLine(user);
    }
}
