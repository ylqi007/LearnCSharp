namespace Exceptions.Exceptions;

public class AuthenticationFailedException : Exception
{
    public string ClientId { get; }

    public AuthenticationFailedException(string clientId, string message)
        : base(message)
    {
        ClientId = clientId;
    }
}
