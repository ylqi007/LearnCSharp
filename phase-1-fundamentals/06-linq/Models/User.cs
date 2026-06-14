namespace Linq.Models;

public class User
{
    public required string Id { get; init; }
    public required string Name { get; init; }
    public required string Department { get; init; }
    public decimal Salary { get; init; }
    public string? Email { get; init; }

    public override string ToString()
    {
        return $"User(Id = {Id}, Name = {Name}, Department = {Department}, Salary = {Salary:C0})";
    }
}
