using DelegatesAndEvents.Models;

namespace DelegatesAndEvents.Services;

public class NotificationService
{
    public void SendOrderNotification(object? sender, OrderCreatedEventArgs e)
    {
        Console.WriteLine($"Notification sent for order {e.Order.Id} at {e.CreatedAt:u}");
    }
}
