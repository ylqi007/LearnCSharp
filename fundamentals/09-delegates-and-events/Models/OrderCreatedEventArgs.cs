namespace DelegatesAndEvents.Models;

public class OrderCreatedEventArgs : EventArgs
{
    public required Order Order { get; init; }
    public DateTime CreatedAt { get; init; }
}
