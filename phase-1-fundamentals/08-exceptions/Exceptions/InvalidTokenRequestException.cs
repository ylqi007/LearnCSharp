namespace Exceptions.Exceptions;

public class InvalidTokenRequestException : Exception
{
    public InvalidTokenRequestException(string message)
        : base(message)
    {
    }
}
