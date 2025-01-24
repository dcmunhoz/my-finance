namespace Result;

public partial class Result<TValue> : IResult
{
    private readonly List<ResultError> _errors = new();

    private Result(TValue? value) 
    {
        Value = value;
        HasErrors = false;
    }

    private Result(ResultError error) 
    {
        _errors.Add(error);
        HasErrors = true;
    }

    private Result(List<ResultError> errors)
    {
        _errors = errors;
        HasErrors = true;
    }

    public TValue? Value { get; set; }
    public bool HasErrors { get; private set; }
    public IReadOnlyList<ResultError> Errors => _errors.AsReadOnly();
}
