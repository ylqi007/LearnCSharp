namespace GlobalExceptionDemo.Exceptions;

public class InvalidUserException : AppException
{
    public InvalidUserException(string message)
        : base("INVALID_USER", message, StatusCodes.Status400BadRequest)
    {
    }
}
