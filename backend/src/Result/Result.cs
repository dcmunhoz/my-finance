namespace Result;

public partial class Result<TValue> : IResult<TValue>, IValidatableResult
{
    private readonly List<ResultError> _errors = new();
    private bool _hasErrors;
    private TValue? _value;

    private Result(TValue? value) 
    {
        _value = value;
        _hasErrors = false;
    }

    private Result(ResultError error) 
    {
        _errors.Add(error);
        _hasErrors = true;
    }

    private Result(List<ResultError> errors)
    {
        _errors = errors;
        _hasErrors = true;
    }

    public TValue? Value { get { return _value; } }
    public bool HasErrors { get {  return _hasErrors; } }
    public IReadOnlyList<ResultError> Errors => _errors.AsReadOnly();
}
