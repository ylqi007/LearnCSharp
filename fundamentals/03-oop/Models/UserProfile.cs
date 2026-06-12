namespace Oop.Models;

public class UserProfile
{
    public required string UserId { get; init; }

    public required string DisplayName { get; init; }

    public Address? Address { get; init; }
}
