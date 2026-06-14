namespace Linq.Models;

public class Product
{
    public required string Id { get; init; }
    public required string Name { get; init; }
    public required string Category { get; init; }
    public decimal Price { get; init; }

    public override string ToString()
    {
        return $"Product(Id = {Id}, Name = {Name}, Category = {Category}, Price = {Price:C2})";
    }
}
