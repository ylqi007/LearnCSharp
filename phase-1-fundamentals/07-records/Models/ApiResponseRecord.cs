namespace Records.Models;

public record ApiResponseRecord<T>(
    bool Success,
    T? Data,
    string? ErrorMessage)
{
    public static ApiResponseRecord<T> Ok(T data)
    {
        return new ApiResponseRecord<T>(
            true,
            data,
            null);
    }

    public static ApiResponseRecord<T> Fail(string errorMessage)
    {
        return new ApiResponseRecord<T>(
            false,
            default,
            errorMessage);
    }
}
