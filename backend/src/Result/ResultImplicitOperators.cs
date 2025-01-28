namespace Result;

public partial class Result<TValue>
{
    public static implicit operator Result<TValue>(TValue value) => new(value);
    public static implicit operator Result<TValue>(ResultError error) => new(error);
    public static implicit operator Result<TValue>(List<ResultError> errors) => new(errors);
}