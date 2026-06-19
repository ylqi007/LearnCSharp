namespace ApiVersioningDemo.Contracts.V2;

public class CreateUserRequest
{
    public string DisplayName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;
}
