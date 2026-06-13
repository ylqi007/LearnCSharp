namespace Collections.Examples;

public static class StackExamples
{
    public static void Run()
    {
        Console.WriteLine();
        Console.WriteLine("===== Stack<T> Examples =====");

        Stack<string> navigationHistory = new();
        navigationHistory.Push("Home");
        navigationHistory.Push("Products");
        navigationHistory.Push("Checkout");

        Console.WriteLine($"Current page = {navigationHistory.Peek()}");

        while (navigationHistory.Count > 0)
        {
            var page = navigationHistory.Pop();
            Console.WriteLine($"Back from {page}");
        }
    }
}
