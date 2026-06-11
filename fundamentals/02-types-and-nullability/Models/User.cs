namespace TypesAndNullability.Models;

public class User
{
    // 必须赋值，永远不应该是 null
    public required string UserId { get; set; }

    // 允许为空
    public string? Email { get; set; }

    public string? DisplayName { get; set; }
}