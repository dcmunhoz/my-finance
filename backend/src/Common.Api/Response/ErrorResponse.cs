using Microsoft.AspNetCore.Mvc;

namespace Common.Api.Response;

public class ErrorResponse
{
    public string? Title { get; set; }
    public string? Message { get; set; }
    public IEnumerable<ErrorDetailsResponse>? Details { get; set; }
}

public class ErrorDetailsResponse
{
    public string Title { get; set; } = String.Empty; 
    public string Message { get; set; } = String.Empty;
}