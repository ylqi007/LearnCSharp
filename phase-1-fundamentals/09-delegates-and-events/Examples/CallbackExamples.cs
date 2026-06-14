namespace DelegatesAndEvents.Examples;

// Callback 就是：
// 把方法作为参数传进去，让另一个方法在合适的时候调用
public static class CallbackExamples
{
    public static void Run()
    {
        Console.WriteLine();
        Console.WriteLine("===== Callback Examples =====");

        ProcessData(
            "sample payload",
            data => Console.WriteLine($"Success callback: {data.ToUpperInvariant()}"),
            error => Console.WriteLine($"Error callback: {error}"));

        ProcessData(
            "",
            data => Console.WriteLine($"Success callback: {data}"),
            error => Console.WriteLine($"Error callback: {error}"));
    }

    private static void ProcessData(string input, Action<string> onSuccess, Action<string> onError)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            onError("Input cannot be empty.");
            return;
        }

        onSuccess(input);
    }
}
