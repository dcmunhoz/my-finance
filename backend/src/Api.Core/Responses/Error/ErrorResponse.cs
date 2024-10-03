namespace Api.Core.Responses.Error;

public class ErrorResponse
{
    public string Title { get; set; }
    public string Message { get; set; }
    public List<ErrorDetail> Details { get; set; } = new List<ErrorDetail>();
}

public class ErrorDetail
{
    public string Title { get; set; }
    public string Message { get; set; } 
}