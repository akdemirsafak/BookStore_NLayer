using System.Text.Json.Serialization;

namespace BookStore.Core.BaseDtos;

public class ApiResponseDto<T>
{
    public T Data { get; set; }
    public List<string> Errors { get; set; }
    [JsonIgnore] public int StatusCode { get; set; }

    public static ApiResponseDto<T> Success(int statusCode, T data)
    {
        return new ApiResponseDto<T>
        {
            Data = data,
            StatusCode = statusCode,
            Errors = null
        };
    }

    public static ApiResponseDto<T> Success(int statusCode)
    {
        return new ApiResponseDto<T>
        {
            StatusCode = statusCode,
            Errors = null
        };
    }

    public static ApiResponseDto<T> Fail(int statusCode, List<string> errorMessages)
    {
        return new ApiResponseDto<T>
        {
            StatusCode = statusCode,
            Errors = errorMessages
        };
    }

    public static ApiResponseDto<T> Fail(int statusCode, string error)
    {
        return new ApiResponseDto<T>
        {
            StatusCode = statusCode,
            Errors = new List<string> { error }
        };
    }
}