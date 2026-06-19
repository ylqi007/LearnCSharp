namespace ApiVersioningDemo.Contracts.V2;

public class UserResponse
{
    public int Id { get; set; }

    public string DisplayName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public bool IsActive { get; set; }
}
