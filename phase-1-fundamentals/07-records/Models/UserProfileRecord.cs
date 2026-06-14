namespace Records.Models;

public record UserProfileRecord(
    string UserId,
    string DisplayName,
    AddressRecord? Address);
