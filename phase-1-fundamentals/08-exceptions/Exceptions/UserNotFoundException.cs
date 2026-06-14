namespace Exceptions.Exceptions;

public class UserNotFoundException : Exception
{
    public string UserId { get; }

    public UserNotFoundException(string userId)
        : base($"User '{userId}' was not found.")
    {
        UserId = userId;
    }
}
