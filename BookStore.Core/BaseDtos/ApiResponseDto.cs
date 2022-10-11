using System.Text.Json.Serialization;

namespace BookStore.Core.BaseDtos;

public class ApiResponseDto<T>
{
    public T Data { get; set; }
    public List<string> Errors { get; set; }
    [JsonIgnore] public int StatusCode { get; set; }

    //Static Factory Method
    public static ApiResponseDto<T> Success(T Data, int statusCode = 0)
    {
        return new ApiResponseDto<T> { Data = Data, StatusCode = statusCode };
    }

    public static ApiResponseDto<T> Success(int statusCode = 0)
    {
        return new ApiResponseDto<T> { Data = default, StatusCode = statusCode };
    }

    public static ApiResponseDto<T> Fail(List<string> errors, int statusCode = 0)
    {
        return new ApiResponseDto<T> { Data = default, Errors = errors, StatusCode = statusCode };
    }

    public static ApiResponseDto<T> Fail(string error, int statusCode = 0)
    {
        return new ApiResponseDto<T> { Data = default, Errors = new List<string> { error }, StatusCode = statusCode };
    }
}