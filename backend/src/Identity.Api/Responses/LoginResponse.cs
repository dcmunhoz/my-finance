namespace Identity.Api.Responses;

public record LoginResponse(string Token, string UserName, string Email);