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
    public async Task<IActionResult> RegisterUserAsync([FromBody] RegisterUserRequest request, CancellationToken cancellationToken)
    {
        RegisterUserRequestValidation validation = new();
        var result = await validation.ValidateAsync(request, cancellationToken);

        if (!result.IsValid)
        {
            var response = new ErrorResponse
            {
                Id = nameof(RegisterUserAsync),
                Title = "Validations errors occurred",
                Details =  result.Errors.Select(s => new ErrorDetailsResponse
                {
                    Title = s.ErrorCode,
                    Message = s.ErrorMessage
                })
            };

            return BadRequest(response);
        }

        if (await _context.Users.AnyAsync(w => w.Email.Trim().Equals(request.Email.Trim()), cancellationToken))
            return BadRequest(new ErrorResponse
            {
                Id = this.GetType().FullName ?? "",
                Title = "E-mail already exists",
                Message = "This e-mail is already registered. If you forget your password try to recovery."
            });
        
        User user = new(request.Name, request.Email, request.Password);
        
        await _context.Users.AddAsync(user, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        
        return Created("/api/auth/login", user);
    }
}