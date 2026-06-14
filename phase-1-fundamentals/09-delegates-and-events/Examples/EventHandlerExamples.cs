using DelegatesAndEvents.Models;

namespace DelegatesAndEvents.Examples;

public static class EventHandlerExamples
{
    public static void Run()
    {
        Console.WriteLine();
        Console.WriteLine("===== EventHandler Examples =====");

        EventHandler<OrderCreatedEventArgs> handler = (sender, e) =>
        {
            Console.WriteLine($"Inline handler received order {e.Order.Id}");
        };

        var order = new Order
        {
            Id = "order-demo",
            UserId = "u001",
            Amount = 49.99M
        };

        handler(
            sender: null,
            e: new OrderCreatedEventArgs
            {
                Order = order,
                CreatedAt = DateTime.UtcNow
            });
    }
}
