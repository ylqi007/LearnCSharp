namespace Generics.Models;

public class ApiResponse<T>
{
    public bool Success { get; init; }

    public T? Data { get; init; }

    public string? ErrorMessage { get; init; }

    public static ApiResponse<T> Ok(T data)
    {
        return new ApiResponse<T>
        {
            Success = true,
            Data = data
        };
    }

    public static ApiResponse<T> Fail(string errorMessage)
    {
        return new ApiResponse<T>
        {
            Success = false,
            ErrorMessage = errorMessage
        };
    }
}
