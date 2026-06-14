namespace DelegatesAndEvents.Examples;

public static class ActionExamples
{
    public static void Run()
    {
        Console.WriteLine();
        Console.WriteLine("===== Action Examples =====");

        Action<string> printMessage = message =>
            Console.WriteLine($"Message: {message}");

        Action<string, string> printUser = (id, name) =>
            Console.WriteLine($"UserId = {id}, Name = {name}");

        printMessage("Hello from Action");
        printUser("u001", "Alex");
    }
}
