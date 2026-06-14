using DelegatesAndEvents.Models;

namespace DelegatesAndEvents.Services;

public class AuditService
{
    public void LogOrderCreated(object? sender, OrderCreatedEventArgs e)
    {
        Console.WriteLine($"Audit log: order {e.Order.Id}, amount {e.Order.Amount:C2}");
    }
}
