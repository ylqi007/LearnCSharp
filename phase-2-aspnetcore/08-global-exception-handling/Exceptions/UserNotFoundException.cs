namespace GlobalExceptionDemo.Exceptions;

public class UserNotFoundException : AppException
{
    public UserNotFoundException(int userId)
        : base("USER_NOT_FOUND", $"User with id {userId} was not found.", StatusCodes.Status404NotFound)
    {
    }
}
