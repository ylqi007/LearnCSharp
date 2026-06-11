namespace TypesAndNullability.Models;

public class Product
{
    public required string ProductId { get; set; }

    public required string Name { get; set; }

    public string? Description { get; set; }

    public decimal Price { get; set; }
}