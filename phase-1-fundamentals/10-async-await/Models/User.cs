namespace AsyncAwait.Models;

public class User
{
    public required string Id { get; init; }
    public required string Name { get; init; }
    public required string Department { get; init; }

    public override string ToString() => $"User(Id = {Id}, Name = {Name}, Department = {Department})";
}
