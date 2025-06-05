
namespace CleanProductApp.Application.DTOs;

public record OperationResult
{
    public bool IsSuccess { get; init; }
    public string Message { get; init; }
    public object? Data { get; init; } 

    public static OperationResult Success(string message, object? data = null)
        => new() { IsSuccess = true, Message = message, Data = data };

    public static OperationResult Failure(string message)
        => new() { IsSuccess = false, Message = message };
}