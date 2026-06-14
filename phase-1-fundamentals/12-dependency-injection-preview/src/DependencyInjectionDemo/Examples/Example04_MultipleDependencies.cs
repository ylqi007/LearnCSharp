using DependencyInjectionDemo.Infrastructure;
using DependencyInjectionDemo.Models;
using DependencyInjectionDemo.Services;

namespace DependencyInjectionDemo.Examples;

public static class Example04_MultipleDependencies
{
    public static void Run()
    {
        Console.WriteLine("\n--- Example 04: Multiple Dependencies ---");

        var logger = new ConsoleAppLogger();
        var emailSender = new FakeEmailSender();
        var service = new NotificationService(emailSender, logger);

        var user = new User("u003", "Cathy", "cathy@example.com", true);
        service.SendWelcomeEmail(user);
    }
}
