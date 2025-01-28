namespace Result;

public record ResultError(string Id, string Title, string Message)
{
    public virtual bool Equals(ResultError? other) => other != null && Id == other.Id;   
}