namespace BalotoAI.Domain.Common;

/// <summary>
/// Result class for operation responses
/// </summary>
public class Result
{
    public bool IsSuccess { get; protected set; }
    public string Message { get; protected set; }
    public IReadOnlyList<string> Errors { get; protected set; }

    protected Result(bool isSuccess, string message, IReadOnlyList<string> errors = null!)
    {
        IsSuccess = isSuccess;
        Message = message;
        Errors = errors ?? new List<string>();
    }

    public static Result Success(string message = "Operation completed successfully")
    {
        return new Result(true, message, new List<string>());
    }

    public static Result Failure(string message, IReadOnlyList<string>? errors = null)
    {
        return new Result(false, message, errors ?? new List<string>());
    }
}

/// <summary>
/// Generic result class for operation responses with data
/// </summary>
public class Result<T> : Result
{
    public T? Data { get; protected set; }

    protected Result(bool isSuccess, string message, T? data, IReadOnlyList<string> errors = null!)
        : base(isSuccess, message, errors)
    {
        Data = data;
    }

    public static Result<T> Success(T data, string message = "Operation completed successfully")
    {
        return new Result<T>(true, message, data, new List<string>());
    }

    public static new Result<T> Failure(string message, IReadOnlyList<string>? errors = null)
    {
        return new Result<T>(false, message, default, errors ?? new List<string>());
    }
}
