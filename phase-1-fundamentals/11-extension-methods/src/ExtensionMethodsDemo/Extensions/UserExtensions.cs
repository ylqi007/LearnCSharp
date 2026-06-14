using ExtensionMethodsDemo.Models;

namespace ExtensionMethodsDemo.Extensions;

public static class UserExtensions
{
    public static string DisplayName(this User user)
    {
        return $"{user.Name} <{user.Email.MaskEmail()}>";
    }

    public static bool WasCreatedWithinDays(this User user, int days)
    {
        return user.CreatedAtUtc >= DateTime.UtcNow.AddDays(-days);
    }

    public static string ToAuditLine(this User user)
    {
        string status = user.IsActive ? "active" : "inactive";
        return $"User {user.Id}: {user.Name} is {status}, created at {user.CreatedAtUtc:yyyy-MM-dd}";
    }
}
