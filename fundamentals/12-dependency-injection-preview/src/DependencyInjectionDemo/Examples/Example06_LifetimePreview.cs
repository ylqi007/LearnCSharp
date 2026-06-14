namespace DependencyInjectionDemo.Examples;

public static class Example06_LifetimePreview
{
    public static void Run()
    {
        Console.WriteLine("\n--- Example 06: Lifetime Preview ---");
        Console.WriteLine("Singleton: one instance for the whole app.");
        Console.WriteLine("Scoped: one instance per request in ASP.NET Core.");
        Console.WriteLine("Transient: new instance every time it is requested.");
    }
}
