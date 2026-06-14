namespace ExtensionMethodsDemo.Extensions;

public static class StringExtensions
{
    public static bool IsBlank(this string? value)
    {
        return string.IsNullOrWhiteSpace(value);
    }

    public static bool IsEmailLike(this string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return false;
        }

        return value.Contains('@') && value.Contains('.');
    }

    public static string MaskEmail(this string email)
    {
        if (!email.IsEmailLike())
        {
            return email;
        }

        string[] parts = email.Split('@');
        string local = parts[0];
        string domain = parts[1];

        string maskedLocal = local.Length <= 2
            ? "**"
            : $"{local[0]}***{local[^1]}";

        return $"{maskedLocal}@{domain}";
    }

    public static string ToTitleCaseSimple(this string value)
    {
        if (value.IsBlank())
        {
            return string.Empty;
        }

        string[] words = value.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        return string.Join(' ', words.Select(word =>
            char.ToUpperInvariant(word[0]) + word[1..].ToLowerInvariant()));
    }
}
