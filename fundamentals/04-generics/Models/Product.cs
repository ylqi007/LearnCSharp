namespace Generics.Models;

public class Product : IEntity
{
    public string Id { get; init; } = string.Empty;

    public string Name { get; init; } = string.Empty;

    public decimal Price { get; init; }

    public override string ToString()
    {
        return $"Product(Id = {Id}, Name = {Name}, Price = {Price:C})";
    }
}
