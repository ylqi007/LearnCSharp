namespace TypesAndNullability.Models;

public class Order
{
    public required string OrderId { get; set; }

    public User? Customer { get; set; }

    public Product? Product { get; set; }
}