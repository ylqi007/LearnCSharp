namespace Linq.Models;

public class Order
{
    public required string Id { get; init; }
    public required string UserId { get; init; }
    public required List<string> ProductIds { get; init; }
    public DateTime CreatedAt { get; init; }

    public override string ToString()
    {
        return $"Order(Id = {Id}, UserId = {UserId}, ProductCount = {ProductIds.Count}, CreatedAt = {CreatedAt:yyyy-MM-dd})";
    }
}
