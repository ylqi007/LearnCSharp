namespace Collections.Models;

public class Order
{
    public required string Id { get; init; }
    public required string UserId { get; init; }
    public required string ProductId { get; init; }
    public int Quantity { get; init; }

    public override string ToString()
    {
        return $"Order(Id = {Id}, UserId = {UserId}, ProductId = {ProductId}, Quantity = {Quantity})";
    }
}
