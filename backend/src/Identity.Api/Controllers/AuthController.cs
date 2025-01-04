using Identity.Api.Data.Context;
using Identity.Api.Models;
using Identity.Api.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IdentityDbContext _context;
    
    public AuthController(IdentityDbContext context)
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