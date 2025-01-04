using Auth.Api.Data.Context;
using Auth.Api.Models;
using Auth.Api.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Auth.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly AuthDbContext _context;
    
    public AuthController(AuthDbContext context)
    {
        _context = context;
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> RegisterUser([FromBody] RegisterUserRequest request)
    {
        User user = new User(request.Username, request.Name, request.Email);
        
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        
        return Created("/api/auth/login", user);
    }
}