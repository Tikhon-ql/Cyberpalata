namespace Cyberpalata.Common
{
    //public class Result
    //{
    //    public bool Success { get; }
    //    public string Error { get; set; }
    //    public bool IsFailure => !Success;

    //    protected Result(bool success, string error = "")
    //    {
    //        if (success && error != string.Empty)
    //            throw new InvalidOperationException();
    //        if (!success && error == string.Empty)
    //            throw new InvalidOperationException();
    //        Success = success;
    //        Error = error;
    //    }

    //    public static Result Fail(string errorMessage) => new Result(false, errorMessage);
    //    public static Result<T> Fail<T>(string errorMessage) => new Result<T>(default(T), false, errorMessage);
    //    public new static Result<T> Ok<T>(T value) => new Result<T>(value, true);
    //    public static Result Ok() => new Result(true);
    //}

    //public class Result<T> : Result
    //{
    //    public T Value { get; set; }
    //    internal Result(T value,bool success, string error = "") : base(success, error)
    //    {
    //        Value = value;
    //    }
    //}
}
