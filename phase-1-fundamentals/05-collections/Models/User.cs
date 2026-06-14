namespace Collections.Models;

public class User
{
    public required string Id { get; init; }
    public required string Name { get; init; }
    public string? Email { get; init; }

    public override string ToString()
    {
        return $"User(Id = {Id}, Name = {Name}, Email = {Email ?? "N/A"})";
    }
}
