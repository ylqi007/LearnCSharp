using DelegatesAndEvents.Services;

namespace DelegatesAndEvents.Examples;

public static class EventExamples
{
    public static void Run()
    {
        Console.WriteLine();
        Console.WriteLine("===== Event Examples =====");

        var orderService = new OrderService();
        var notificationService = new NotificationService();
        var auditService = new AuditService();

        orderService.OrderCreated += notificationService.SendOrderNotification;
        orderService.OrderCreated += auditService.LogOrderCreated;

        var order = orderService.CreateOrder("u001", 299.99M);
        Console.WriteLine($"Created order: {order}");

        orderService.OrderCreated -= auditService.LogOrderCreated;

        Console.WriteLine("Audit handler unsubscribed.");
        orderService.CreateOrder("u001", 129.99M);
    }
}
