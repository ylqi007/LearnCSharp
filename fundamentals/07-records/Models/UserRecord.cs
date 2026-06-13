namespace Records.Models;

// positional record
// 它自动生成：
// Constructor
// Id / Name / Email properties
// ToString()
// Equals()
// GetHashCode()
// value equality
public record UserRecord(
    string Id,
    string Name,
    string? Email);
