using Common.Api.Response;
using Identity.Api.Data.Context;
using Identity.Api.Models;
using Identity.Api.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Identity.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class IdentityController : ControllerBase
{
    private readonly IdentityDbContext _context;
    
    public IdentityController(IdentityDbContext context)
    {
        _context = context;
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> RegisterUser([FromBody] RegisterUserRequest request)
    {
        if (await _context.Users.AnyAsync(w => w.Username.Trim().Equals(request.Username.Trim())))
            return BadRequest(new ErrorResponse
            {
                Id = this.GetType().FullName ?? "",
                Title = "User already exists",
                Message = "This user already exists, try another one."
            });

        if (await _context.Users.AnyAsync(w => w.Email.Trim().Equals(request.Email.Trim())))
            return BadRequest(new ErrorResponse
            {
                Id = this.GetType().FullName ?? "",
                Title = "E-mail already exists",
                Message = "This e-mail is already registred. If you forget your password try to recovery."
            });
        
        User user = new User(request.Username, request.Name, request.Email);
        
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        
        return Created("/api/auth/login", user);
    }
}