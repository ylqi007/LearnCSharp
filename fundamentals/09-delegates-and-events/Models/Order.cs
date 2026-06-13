namespace DelegatesAndEvents.Models;

public class Order
{
    public required string Id { get; init; }
    public required string UserId { get; init; }
    public decimal Amount { get; init; }

    public override string ToString()
    {
        return $"Order(Id = {Id}, UserId = {UserId}, Amount = {Amount:C2})";
    }
}
