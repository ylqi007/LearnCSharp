namespace DelegatesAndEvents.Models;

public class User
{
    public required string Id { get; init; }
    public required string Name { get; init; }
    public required string Department { get; init; }
    public bool IsActive { get; init; }

    public override string ToString()
    {
        return $"User(Id = {Id}, Name = {Name}, Department = {Department}, IsActive = {IsActive})";
    }
}
