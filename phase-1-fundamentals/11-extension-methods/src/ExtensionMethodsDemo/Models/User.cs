namespace ExtensionMethodsDemo.Models;

public sealed record User(
    string Id,
    string Name,
    string Email,
    bool IsActive,
    DateTime CreatedAtUtc);
