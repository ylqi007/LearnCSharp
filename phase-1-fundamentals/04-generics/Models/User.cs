namespace Generics.Models;

public class User : IEntity
{
    public string Id { get; init; } = string.Empty;

    public string Name { get; init; } = string.Empty;

    public string? Email { get; init; }

    public override string ToString()
    {
        return $"User(Id = {Id}, Name = {Name}, Email = {Email ?? "N/A"})";
    }
}
