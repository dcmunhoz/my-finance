using Microsoft.AspNetCore.Mvc;

namespace Common.Api.Response;

public class ErrorResponse
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string Message { get; set; }
}