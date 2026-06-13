using DelegatesAndEvents.Models;

namespace DelegatesAndEvents.Services;

public class OrderService
{
    public event EventHandler<OrderCreatedEventArgs>? OrderCreated;

    public Order CreateOrder(string userId, decimal amount)
    {
        var order = new Order
        {
            Id = $"order-{Guid.NewGuid():N}"[..14],
            UserId = userId,
            Amount = amount
        };

        OnOrderCreated(order);
        return order;
    }

    protected virtual void OnOrderCreated(Order order)
    {
        OrderCreated?.Invoke(
            this,
            new OrderCreatedEventArgs
            {
                Order = order,
                CreatedAt = DateTime.UtcNow
            });
    }
}
