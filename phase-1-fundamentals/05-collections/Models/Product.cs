namespace Collections.Models;

public class Product
{
    public required string Id { get; init; }
    public required string Name { get; init; }
    public decimal Price { get; init; }

    public override string ToString()
    {
        return $"Product(Id = {Id}, Name = {Name}, Price = {Price:C2})";
    }
}
