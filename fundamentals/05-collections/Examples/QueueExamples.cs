namespace Collections.Examples;

public static class QueueExamples
{
    public static void Run()
    {
        Console.WriteLine();
        Console.WriteLine("===== Queue<T> Examples =====");

        Queue<string> messageQueue = new();
        messageQueue.Enqueue("message-001");
        messageQueue.Enqueue("message-002");
        messageQueue.Enqueue("message-003");

        Console.WriteLine($"Peek = {messageQueue.Peek()}");

        while (messageQueue.Count > 0)
        {
            var message = messageQueue.Dequeue();
            Console.WriteLine($"Processing {message}");
        }
    }
}
