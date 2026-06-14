using DependencyInjectionDemo.Interfaces;

namespace DependencyInjectionDemo.Infrastructure;

public sealed class ConsoleAppLogger : IAppLogger
{
    public void Info(string message)
    {
        Console.WriteLine($"[INFO] {message}");
    }

    public void Error(string message)
    {
        Console.WriteLine($"[ERROR] {message}");
    }
}
