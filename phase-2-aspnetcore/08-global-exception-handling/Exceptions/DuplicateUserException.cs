namespace GlobalExceptionDemo.Exceptions;

public class DuplicateUserException : AppException
{
    public DuplicateUserException(int userId)
        : base("DUPLICATE_USER", $"User with id {userId} already exists.", StatusCodes.Status409Conflict)
    {
    }
}
