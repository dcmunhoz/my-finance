namespace Result;

public interface IValidatableResult;

public interface IResult<TValue>
{
    public bool HasErrors { get; }
    public IReadOnlyList<ResultError> Errors { get; }
    public TValue? Value { get; }
}